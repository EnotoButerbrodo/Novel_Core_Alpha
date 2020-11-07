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
using System.IO.Compression;


namespace Novel_Core_Alpha
{

    public partial class NC_Editor : Form
    {
        string contentFolderPath;//Хранение пути до папки контента
        string contentFolderName = "NCE_content";//Название папки контента
        string curr_scene_path = "None";
        int selected_frame = 0, selected_buff = 0;
        //Создаем нужную папку в регистре, если её нету и так же переменную, чтобы работать с регистром по этому адресу
        RegistryKey AddContentKey = Registry.CurrentUser.CreateSubKey(@"Software\NCE\AddContent");
        //
        List<string> backgrounds = new List<string>(); //Содержит список доступных фонов
        List<string> texts = new List<string>(); //Список допступных текстов
        List<Frame> curr_scene = new List<Frame>();//Этот лист содержит текущую сцену
        List<PictureBox> curr_scene_frames = new List<PictureBox>(); //Храняться кадры для отображения
        //
        BinaryFormatter formatter = new BinaryFormatter();//Эта штука для сериализации
        string[] CFDirectories =
        {
            "Backgrounds",
            "Characters",
            "Scenes",
            "Sounds"
        };
        enum CFDirectoryName
        {
            Backgrounds = 0,
            Characters = 1,
            Scenes = 2,
            Sounds = 3
        };

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
            Delete_background_button.Enabled = false;//Деактивируем кнопку
            Frame_text.Enabled = false;

        }
        

        //Функция формирует список всех файлов в директории
        void ReadBackgroundsFiles()
        {
            //Если директория существует
            if (Directory.Exists($"{contentFolderPath}\\{CFDirectories[(int)CFDirectoryName.Backgrounds]}"))
            {
                backgrounds.Clear();
                Backgrounds_list.Items.Clear();
                //Массив содержит имена всех файлов что мы выбрали
                string[] files = Directory.GetFiles($"{contentFolderPath}\\{CFDirectories[(int)CFDirectoryName.Backgrounds]}");//Считываем в массив имена всех файлов в папке

                for (int i = 0; i < files.Length; i++)
                {
                    backgrounds.Add(files[i]);//ДОбавление во внутренний список
                    Backgrounds_list.Items.Add(Path.GetFileName(backgrounds[i])); //Список на отображение
                }          
            }
        }

        //Выбор или создание папки контента
        private void ContenFolderSetPath_button_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog FBD = new FolderBrowserDialog())
            {
                try
                {
                    if (FBD.ShowDialog() == DialogResult.OK)//Если завершили выбор
                    {
                        //Если выбранная папка и есть папка контента
                        if (FBD.SelectedPath.Contains($"\\{ contentFolderName}"))
                        {
                            AddContentKey.SetValue("ContentFolderPath", FBD.SelectedPath);
                            contentFolderPath = AddContentKey.GetValue("ContentFolderPath").ToString();
                            ContentFolderPathStoke.Text = contentFolderPath;
                            return;
                        }
                        //Если в выбранной папке не содержит папку контента
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
                    else return;
                    
                }
                catch
                {
                    MessageBox.Show("Не удалось выбрать папку", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }   
            }
           // ReadBackgroundsFiles();
        }

        //Создание новой пустой папки контента
        private string CreateContentFolder(string path)
        {
            path += $"\\{contentFolderName}";
            Directory.CreateDirectory(path);
            foreach(string dir in CFDirectories)
            {
                Directory.CreateDirectory($"{path}\\{dir}");
            }
            return path;
        }

        //Добавить задний фон в библиотеку
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
                                newPath = $"{contentFolderPath}\\{CFDirectories[(int)CFDirectoryName.Backgrounds]}\\{Path.GetFileName(path)}";
                                File.Copy(path, newPath);
                                try
                                {
                                    backgrounds.Add(newPath);
                                    Backgrounds_list.Items.Add(Path.GetFileName(backgrounds[backgrounds.Count - 1]));
                                }
                                catch
                                {
                                    MessageBox.Show("Не удалось добавить файл в библиотеку",
                                      "Ошибка",
                                      MessageBoxButtons.OK,
                                      MessageBoxIcon.Error
                                       );
                                }
                            }
                            catch
                            {
                                MessageBox.Show("Не удалось добавить файл",
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

        //Обработка выбора элемента списка с задними фонами
        async private void Backgrounds_list_SelectedIndexChanged(object sender, EventArgs e)
        {
            Delete_background_button.Enabled = true;//Активируем кнопку удалить фон
            try
            {
                Backgrounds_previe.Image = Backgrounds_previe.InitialImage;
                await Task.Run(() =>
                {
                    //Делаем поток который будет читать файл с изображением
                    using (FileStream stream = new FileStream(backgrounds[Backgrounds_list.SelectedIndex], FileMode.Open
                        ,FileAccess.Read))
                    {
                        //Полученную картинку отображаем
                        Backgrounds_previe.Image = Image.FromStream(stream);
                    }
                });
            }
            catch { };
        }

        //При обновлении путь до папки контента заново считываем все доступные файлы
        private void ContentFolderPathStoke_TextChanged(object sender, EventArgs e)
        {
            ReadBackgroundsFiles();
            ReadCharacterFolders();
        }

        public void ReadCharacterFolders()
        {
            if (Directory.Exists($"{contentFolderPath}\\{CFDirectories[(int)CFDirectoryName.Characters]}"))
            {
                string dirr;
                Characters_combobox.Items.Clear();
                //Массив содержит имена всех файлов что мы выбрали
                string[] directory = Directory.GetDirectories($"{contentFolderPath}\\{CFDirectories[(int)CFDirectoryName.Characters]}");//Считываем в массив имена всех файлов в папке

                foreach (string dir in directory)
                {
                    Characters_combobox.Items.Add(Path.GetFileName(dir));
                }

            }
        }

        //Кнопка удаления заднего фона из коллекции
        private void Delete_background_button_Click(object sender, EventArgs e)
        {
            int buff = Backgrounds_list.SelectedIndex;//Сохраняем текущий выбранный индекс
            Backgrounds_previe.Image = Backgrounds_previe.InitialImage;//На превью ставим картинку ожидания
  
            File.Delete(backgrounds[buff]); //Удаляем файл из папки
            backgrounds.RemoveAt(buff);//Удаляем из списка ресурсов
            Backgrounds_list.Items.RemoveAt(buff); //Удаляем из списка на отображение
            if (Backgrounds_list.SelectedIndex >= 0)
                Backgrounds_list.SelectedIndex--;
            else
                Backgrounds_list.SelectedIndex = 0;
        }

        //Установить картинку как фон фрейма
        private void SetBackground_button_Click(object sender, EventArgs e)
        {
            if (Backgrounds_list.SelectedIndex != -1)
            {
                SceneEditor_previe.Image = Backgrounds_previe.Image;
                curr_scene[selected_frame].background = backgrounds[Backgrounds_list.SelectedIndex];
                curr_scene_frames[selected_frame].Image = SceneEditor_previe.Image;
                DisplayFrameInfo();
            }
        }

        //Сoхранить сцену в файл
        private void saveScene_menu_button_Click(object sender, EventArgs e)
        {
                using (FileStream fs = new FileStream(curr_scene_path, FileMode.Create))
                {
                    formatter.Serialize(fs, curr_scene);
                }
        }

        //Открытие сохраненной сцены
        private void OpenScene_menu_button_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog opd = new OpenFileDialog())
            {
                selected_frame = selected_buff = 0; //Обнуление текущего выбранного кадра
                SelectedFrame.Value = 0;
                Frame_previe.Items.Clear();
                opd.Filter = "Сцена|*.scene";
                opd.Title = "Выбирай файл";
                opd.InitialDirectory = $"{contentFolderPath}\\{CFDirectories[(int)CFDirectoryName.Scenes]}";
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

        //Сохранение сцены в файл
        private void SaveAsNewScene_menu_button_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "Сцена|*.scene";
                sfd.Title = "Выбирай файлы";
                sfd.DefaultExt = ".scene";
                sfd.InitialDirectory = $"{contentFolderPath}\\{CFDirectories[(int)CFDirectoryName.Scenes]}";
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
        
        //Отображение всех фреймов сцены
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
                    curr_scene_frames[i].Location = new Point(curr_scene_frames[i - 1].Location.X + 
                        curr_scene_frames[i - 1].Width + 5,
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
                for (int i = 0; i < curr_scene_frames.Count; i++)
                {
                    if (File.Exists(curr_scene[i].background))
                        using (FileStream stream = new FileStream(curr_scene[i].background,
                               FileMode.Open,
                               FileAccess.Read))
                        {
                            curr_scene_frames[i].Image = Image.FromStream(stream);                  
                        }
                    else curr_scene_frames[i].Image = null; 
                }  
            });
        }

        //Обработка клика по фрейму
        private void Frame_Click(object sender, EventArgs e)
        {
            SetBackground_button.Enabled = true;
            Frame_text.Enabled = true;
            var frame = sender as PictureBox;
            SceneEditor_previe.Image = frame.Image;
            selected_frame = (int)frame.Tag;
            frame.BackColor = Color.Aqua;
            if (selected_frame != selected_buff)
            {
                curr_scene_frames[selected_buff].BackColor = Color.Black;
                selected_buff = selected_frame;
            }
            SelectedFrame.Value = selected_frame;
            Frame_text.Text = curr_scene[selected_frame].text;
            //Выводим информацию о фрейме
            try
            {
                DisplayFrameInfo();
            }
            catch { }
        }

        //Функция отобразит в опредеённом поле информацию о выбранном фрейме
        void DisplayFrameInfo()
        {
            Frame_previe.Items.Clear();
            Frame_previe.Items.Add("Задний фон: ");
            Frame_previe.Items.Add(Path.GetFileNameWithoutExtension(curr_scene[selected_frame].background));
        }

        private void Frame_text_TextChanged(object sender, EventArgs e)
        {
            curr_scene[selected_frame].text = Frame_text.Text;
        }

        private void Characters_combobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string[] files = Directory.GetFiles($"{contentFolderPath}\\{CFDirectories[(int)CFDirectoryName.Characters]}\\" +
                $"{Characters_combobox.Items[Characters_combobox.SelectedIndex]}"); 
            imageList1.ImageSize = new Size(128, 128);

            for(int i = 0; i < files.Length; i++)
            {
                imageList1.Images.Add(Image.FromFile(files[i]));
                ListViewItem lvi = new ListViewItem(new string[] { "", Path.GetFileNameWithoutExtension(files[i]) });
                lvi.ImageIndex = i;
                listView2.Items.Add(lvi);
            }
            SceneEditor_previe.Image = imageList1.Images[0];
            listView2.SmallImageList = imageList1;
        }

        private void Zip_button_Click(object sender, EventArgs e)
        {
            string startPath = @"C:\Users\Игорь\Desktop\done\NCE_content\Backgrounds";
            string zipPath = @"C:\Users\Игорь\Desktop\done\NCE_content\images.nca";
            ZipFile.CreateFromDirectory(startPath, zipPath, CompressionLevel.Fastest, false);
        }

        private void UnZip_button_Click(object sender, EventArgs e)
        {
            string startPath = @"C:\Users\Игорь\Desktop\done\NCE_content\Backgrounds2";
            Directory.CreateDirectory(startPath);
            string zipPath = @"C:\Users\Игорь\Desktop\done\NCE_content\images.nca";
            ZipFile.ExtractToDirectory(zipPath, startPath);
        }

        private void ReadZip_button_Click(object sender, EventArgs e)
        {
            string zipPath = @"C:\Users\Игорь\Desktop\done\NCE_content\images.zip";
            using (ZipArchive archive = ZipFile.Open(zipPath, ZipArchiveMode.Read))
            {
                foreach (var entry in archive.Entries)
                {
                    if (entry.FullName.Contains("Monika") & entry.Name.Contains(".png"))
                    {
                        Frame_previe.Items.Add(entry.Name);
                        entry.ExtractToFile($"{contentFolderPath}\\{entry.Name}", true);
                    }

                    //Frame_previe.Items.Add(entry.FullName);
                    //if (entry.FullName.Contains("Backgrounds"))
                    //{
                    //    MessageBox.Show("1");
                    //    entry.ExtractToFile($"{contentFolderPath}\\{entry.FullName}", true);
                    //}
                }

            }
        }

        //Добавление нового фрейма в проект
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
