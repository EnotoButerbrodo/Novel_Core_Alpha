using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;

namespace Novel_Core_Alpha
{

    public partial class NC_Editor : Form
    {
        string contentFolderPath;//Хранение пути до папки контента
        string contentFolderName = "NCE_content";//Название папки контента
        int directorySize = 0;
        string curr_scene_path = "None";
        int selected_frame = 0, selected_buff = 0;
        //Создаем нужную папку в регистре, если её нету и так же переменную, чтобы работать с регистром по этому адресу
        RegistryKey AddContentKey = Registry.CurrentUser.CreateSubKey(@"Software\NCE\AddContent");

        class DATA_LIST
        {
            public DATA_LIST() { }

            public DATA_LIST(string path, string name = "Non")
            {
                this.name = name;
                this.path = path;
            }
            public string path;
            public string name;
            public void SetName(string name) => this.name = name;
            public void SetPath(string path) => this.path = path;

        }


        List<string> backgrounds_list = new List<string>();
        List<string> text_list = new List<string>();
        List<Frame> curr_scene = new List<Frame>();//Этот лист содержит текущую сцену
        List<PictureBox> curr_scene_frames = new List<PictureBox>();

        BinaryFormatter formatter = new BinaryFormatter();//Эта штука для сериализации

        public NC_Editor()
        {
            InitializeComponent();
            //Чтение из регистра адреса папки контента
            {
                object buff = AddContentKey.GetValue("ContentFolderPath");
                //Если параметр адреса папки не существует
                if (buff == null)
                    AddContentKey.SetValue("ContentFolderPath", "None");
                //Если параметр есть и его значение является путем до папки
                else if (buff.ToString() != "None")
                {
                    if (Directory.Exists(buff.ToString()))
                    {
                        contentFolderPath = buff.ToString();
                        ContentFolderPathStoke.Text = contentFolderPath;
                        directorySize = Directory.GetFiles($"{contentFolderPath}\\Backgrounds").Length;
                    }
                    else
                    {
                        ContentFolderPathStoke.Text = "Папка контента недействительна. Выбирите новую папку";
                        AddContentKey.SetValue("ContentFolderPath", "None");
                        contentFolderPath = "";
                    }
                }

            }
            SaveScene_menu_button.Enabled = false;
            SetBackground_button.Enabled = false;

        }
        

        //Функция формирует список всех файлов в директории
        void ReadBackgroundsFiles()
        {
            //Если директория существует
            if (Directory.Exists($"{contentFolderPath}\\Backgrounds"))
            {
                backgrounds_list.Clear();
                Backgrounds_list.Items.Clear();
       
                string[] files = Directory.GetFiles($"{contentFolderPath}\\Backgrounds");//Считываем в массив имена всех файлов в папке

                for (int i = 0; i < Directory.GetFiles($"{contentFolderPath}\\Backgrounds").Length; i++)
                {
                    //backgrounds_image_list.Add(new DATA_LIST());//ДОбавляем новый эелемент
                    backgrounds_list.Add(files[i]);
                    Backgrounds_list.Items.Add(Path.GetFileName(backgrounds_list[i]));
                }
                           
            }
        }

        private void ContenFolderSetPath_button_Click(object sender, EventArgs e)//Выбор или создание папки контента
        {
            using (FolderBrowserDialog FBD = new FolderBrowserDialog())
            {
                try
                {
                    if (FBD.ShowDialog() == DialogResult.OK)//Если диалог успешно завершне
                    {
                        //Если выбранная папка и есть папка контента
                        if (FBD.SelectedPath.Contains($"\\{ contentFolderName}"))
                        {
                            AddContentKey.SetValue("ContentFolderPath", FBD.SelectedPath);
                            contentFolderPath = AddContentKey.GetValue("ContentFolderPath").ToString();
                            ContentFolderPathStoke.Text = contentFolderPath;
                            return;
                        }
                        //Если в выбранной папке есть папка контента
                        if (!Directory.Exists(FBD.SelectedPath + "\\" + contentFolderName))
                        {
                            //Спрашиваем хочет ли пользователь создать новую папку контента
                            switch (MessageBox.Show("Создать новую папку контента?",
                                                     "Папка контента не найдена",
                                                     MessageBoxButtons.YesNo,
                                                     MessageBoxIcon.Warning))
                            {
                                case DialogResult.Yes:
                                    contentFolderPath = CreateContentFolder(FBD.SelectedPath);
                                    AddContentKey.SetValue("ContentFolderPath", contentFolderPath);//Сохраняем в регистр путь

                                    Directory.CreateDirectory(contentFolderPath);

                                    ContantFolderStatus.Text = "Создана новая папка контента";
                                    ContentFolderPathStoke.Text = contentFolderPath;
                                    MessageBox.Show("Контентная папка успешно создана", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    
                                    break;
                                case DialogResult.No:
                                    contentFolderPath = null;
                                    ContantFolderStatus.Text = "Папка контента не была выбрана или создана";
                                    break;
                            }
                        }
                        else
                        {
                            ContentFolderPathStoke.Text = contentFolderPath = FBD.SelectedPath + "\\" + contentFolderName;
                            AddContentKey.SetValue("ContentFolderPath", contentFolderPath);
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("Не удалось выбрать папку", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }   
            }
           // ReadBackgroundsFiles();
        }

        private string CreateContentFolder(string path)
        {
            path += $"\\{contentFolderName}";
            Directory.CreateDirectory(path);
            Directory.CreateDirectory($"{path}\\Backgrounds");
            Directory.CreateDirectory($"{path}\\Sounds");
            Directory.CreateDirectory($"{path}\\Characters");
            Directory.CreateDirectory($"{path}\\Scenes");

            return path;
        }

        private void Add_background_button_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog opd = new OpenFileDialog())
            {
                opd.Filter = "Картинки|*.png;*jpg";
                opd.Multiselect = true;
                opd.Title = "Выбирай файлы";
                string newPath; //Храним новый путь до файла

                try
                {
                    if (opd.ShowDialog() == DialogResult.OK) {


                        foreach (string path in opd.FileNames)
                        {
                            try
                            {
                                newPath = $"{contentFolderPath}\\Backgrounds\\{Path.GetFileName(path)}";
                                File.Copy(path, newPath);
                                try
                                {
                                    backgrounds_image_list.Add(new DATA_LIST());//Добавляем в список новый элемент
                                    //Записываем в новый элемент путь и имя файла
                                    backgrounds_image_list[backgrounds_image_list.Count - 1].path = newPath;
                                    backgrounds_image_list[backgrounds_image_list.Count - 1].name = Path.GetFileName(newPath);
                                    //Добавляем в список отображения имя этого нового элемента
                                    Backgrounds_list.Items.Add(backgrounds_image_list[backgrounds_image_list.Count - 1].name);
                                }
                                catch
                                {
                                    MessageBox.Show("Не удалось добавить list!!!",
                                      "Ошибка",
                                      MessageBoxButtons.OK,
                                      MessageBoxIcon.Error
                                       );
                                }
                            }
                            catch
                            {
                                MessageBox.Show("Не удалось добавить файл!!!",
                                      "Ошибка",
                                      MessageBoxButtons.OK,
                                      MessageBoxIcon.Error
                                       );
                            }
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("Не удалось добавить файл!",
                        "Ошибка",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                        );
                }
            }
        }

        async private void Backgrounds_list_SelectedIndexChanged(object sender, EventArgs e)
        {
            Delete_background_button.Enabled = true;//Активируем кнопку удалить фон
            try
            {
                BackgroundImage_previe.Image = BackgroundImage_previe.InitialImage;
                await Task.Run(() =>
                {
                    //Делаем поток который будет читать файл с изображением
                    using (FileStream stream = new FileStream(backgrounds_image_list[Backgrounds_list.SelectedIndex].path, FileMode.Open
                        ,FileAccess.Read))
                    {
                        //Полученную картинку отображаем
                        BackgroundImage_previe.Image = Image.FromStream(stream);
                    }
                });
                
            }
            catch { };
            
        }

        private void ContentFolderPathStoke_TextChanged(object sender, EventArgs e)
        {
            ReadBackgroundsFiles();
        }

        private void Delete_background_button_Paint(object sender, PaintEventArgs e)
        {
            if (Backgrounds_list.SelectedIndex == -1) Delete_background_button.Enabled = false;//Деактивируем кнопку
        }

        private void Delete_background_button_Click(object sender, EventArgs e)
        {
            int buff = Backgrounds_list.SelectedIndex;//Сохраняем текущий выбранный индекс
            BackgroundImage_previe.Image = BackgroundImage_previe.InitialImage;//На превью ставим картинку ожидания
  
            File.Delete(backgrounds_image_list[buff].path);
            backgrounds_image_list.RemoveAt(buff);
            Backgrounds_list.Items.RemoveAt(buff);
            if (Backgrounds_list.SelectedIndex >= 0)
                Backgrounds_list.SelectedIndex--;
            else
                Backgrounds_list.SelectedIndex = 0;

        }


        private void SetBackground_button_Click(object sender, EventArgs e)
        {
            /*
            if (Backgrounds_list.SelectedIndex != -1)
            {
                SceneEditor_previe.Image = BackgroundImage_previe.Image;
                curr_scene[selected_frame].background = backgrounds_image_list[Backgrounds_list.SelectedIndex].name;
                curr_scene_frames[selected_frame].Image = SceneEditor_previe.Image;
                DisplayFrameInfo();
            }
            */
        }

        //Сoхранить сцену
        private void saveScene_menu_button_Click(object sender, EventArgs e)
        {
                using (FileStream fs = new FileStream(curr_scene_path, FileMode.Create))
                {
                    formatter.Serialize(fs, curr_scene);
                }
        }

        private void OpenScene_menu_button_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog opd = new OpenFileDialog())
            {
                selected_frame = selected_buff = 0;
                SelectedFrame.Value = 0;
                CurrFrame_previe.Items.Clear();
                opd.Filter = "Сцена|*.scene";
                opd.Title = "Выбирай файлы";
                opd.InitialDirectory = $"{contentFolderPath}\\Scene";
                if(opd.ShowDialog() == DialogResult.OK)
                {
                    using (FileStream fs = new FileStream(opd.FileName, FileMode.Open))
                    {
                        curr_scene = (List<Frame>)formatter.Deserialize(fs);
                        curr_scene_path = opd.FileName;
                        SaveScene_menu_button.Enabled = true;
                    }
                }
                curr_scene_label.Text = $"Текущая сцена: {Path.GetFileNameWithoutExtension(opd.FileName)}";
                LoadListToFramesPanel();
                


            }
        }

        private void SaveAsNewScene_menu_button_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "Сцена|*.scene";
                sfd.Title = "Выбирай файлы";
                sfd.DefaultExt = ".scene";
                sfd.InitialDirectory = $"{contentFolderPath}\\Scene";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    using (FileStream fs = new FileStream(sfd.FileName, FileMode.Create))
                    {
                        formatter.Serialize(fs, curr_scene);
                    }
                    curr_scene_path = sfd.FileName;
                }
          
              }
        }
        
        async private void LoadListToFramesPanel()
        { 
            curr_scene_frames.Clear();//Очишаем текучий список для работы со сценой
            this.FramesPanel.Controls.Clear();//Ощищаем панель для отображения фреймов

            for (int i = 0; i < curr_scene.Count; i++) { 
                curr_scene_frames.Add(new PictureBox());
                curr_scene_frames[i].Width = 240;
                curr_scene_frames[i].Height = 120;
                if (i == 0)
                    curr_scene_frames[i].Location = new Point(10,10);
                else
                    curr_scene_frames[i].Location = new Point(curr_scene_frames[i - 1].Location.X + curr_scene_frames[i - 1].Width + 5,
                        curr_scene_frames[i - 1].Location.Y);

                curr_scene_frames[i].Name = $"Fr{i}";
                curr_scene_frames[i].Tag = i;
                curr_scene_frames[i].BackColor = Color.Black;
                curr_scene_frames[i].SizeMode = PictureBoxSizeMode.Zoom;
                curr_scene_frames[i].Click += new System.EventHandler(this.Frame_Click);
                this.FramesPanel.Controls.Add(curr_scene_frames[i]);
            }
            await Task.Run(() =>
            {
                //Делаем поток который будет читать файл с изображением

                for (int i = 0; i < curr_scene_frames.Count; i++)
                {
                    /*
                    if (File.Exists($"{contentFolderPath}\\Backgrounds\\{curr_scene[i].background}"))
                        using (FileStream stream = new FileStream($"{contentFolderPath}\\Backgrounds\\{curr_scene[i].background}", FileMode.Open
                    , FileAccess.Read))
                    {
                       
                            curr_scene_frames[i].Image = Image.FromStream(stream);                  
                          
                    }
                    else curr_scene_frames[i].Image = null;
                    */
                }  
            });
        }
        private void Frame_Click(object sender, EventArgs e)
        {
            SetBackground_button.Enabled = true;
            var frame = sender as PictureBox;
            //frame.Tag = 1;
            SceneEditor_previe.Image = frame.Image;
            selected_frame = (int)frame.Tag;
            frame.BackColor = Color.Aqua;
            if (selected_frame != selected_buff)
            {
                curr_scene_frames[selected_buff].BackColor = Color.Black;
                selected_buff = selected_frame;
            }
            SelectedFrame.Value = selected_frame;

            //Выводим информацию о фрейме
            try
            {
                DisplayFrameInfo();
            }
            catch { }

        }

        void DisplayFrameInfo()
        {
            /*
            CurrFrame_previe.Items.Clear();
            CurrFrame_previe.Items.Add("Задний фон: ");
            CurrFrame_previe.Items.Add(curr_scene[selected_frame].background);
            */
        }
        private void AddFrame_button_Click(object sender, EventArgs e)
        {
            curr_scene.Add(new Frame());
            curr_scene_frames.Add(new PictureBox());
            int newframe = curr_scene_frames.Count-1;
            curr_scene_frames[newframe].Width = 240;
            curr_scene_frames[newframe].Height = 120;
            if (newframe == 0)
                curr_scene_frames[newframe].Location = new Point(10, 10);
            else
                curr_scene_frames[newframe].Location = new Point(
                    curr_scene_frames[newframe - 1].Location.X + curr_scene_frames[newframe - 1].Width + 5,
                    curr_scene_frames[newframe - 1].Location.Y
                    );

            curr_scene_frames[newframe].Name = $"Fr{newframe}";
            curr_scene_frames[newframe].Tag = newframe;
            curr_scene_frames[newframe].BackColor = Color.Black;
            curr_scene_frames[newframe].SizeMode = PictureBoxSizeMode.Zoom;
            curr_scene_frames[newframe].Click += new System.EventHandler(this.Frame_Click);
            this.FramesPanel.Controls.Add(curr_scene_frames[newframe]);

        }

        
    }
}
