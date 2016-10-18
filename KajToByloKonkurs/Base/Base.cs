using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


namespace KajToBylo
{
    class Base
    {
        private string Name;
        private Dictionary<KajToBylo.MainWindow.IndexCategory, Category> dictinaryCategory;


        public Base(string name)
        {
            Name = name;

            dictinaryCategory = new Dictionary<MainWindow.IndexCategory, Category>();
            dictinaryCategory.Add(KajToBylo.MainWindow.IndexCategory.MusicPL, new Category());
            dictinaryCategory.Add(KajToBylo.MainWindow.IndexCategory.MusicSL, new Category());
            dictinaryCategory.Add(KajToBylo.MainWindow.IndexCategory.Movie, new Category());
            dictinaryCategory.Add(KajToBylo.MainWindow.IndexCategory.Book, new Category());

        }

        public Category GetCategory(KajToBylo.MainWindow.IndexCategory key)
        {
            return dictinaryCategory[key];
        }

        public void SetCategory(KajToBylo.MainWindow.IndexCategory key, QuestionAnswers question)
        {
            dictinaryCategory[key].AddQuestion(question);
        }

        public void DeleteQuestion(KajToBylo.MainWindow.IndexCategory key, QuestionAnswers question)
        {
            dictinaryCategory[key].DeleteQuestion(question);
        }

        /* public void Used(KajToBylo.MainWindow.IndexCategory key, QuestionAnswers question)
         {
             dictinaryCategory[key].Used(question);
         }*/

        public void WriteAll()
        {
            string folder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            if (!Directory.Exists(folder + @"\KajToBylo\" + Name))
                Directory.CreateDirectory(folder + @"\KajToBylo\" + Name);

            for (int i = 0; i < dictinaryCategory.Count; i++)
            {
                using (Stream output = File.Create(folder + @"\KajToBylo\" + Name + @"\" + KajToBylo.MainWindow.NameCategory[i] + @".ktb"))
                {
                    BinaryFormatter bf = new BinaryFormatter();

                    bf.Serialize(output, dictinaryCategory[(KajToBylo.MainWindow.IndexCategory)i]);
                }
            }
        }

        public void ReadALL(string folder)
        {
            for (int i = 0; i < dictinaryCategory.Count; i++)
            {
                using (Stream input = File.OpenRead(folder + @"\" + KajToBylo.MainWindow.NameCategory[i] + @".ktb"))
                {
                    BinaryFormatter bf = new BinaryFormatter();

                    dictinaryCategory[(KajToBylo.MainWindow.IndexCategory)i].AddQuestionRange((Category)bf.Deserialize(input));
                }
            }
        }


        /*    public void ReadAll(string name, Base obj)
            {
                string folder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

                using (Stream input = File.OpenRead(folder + @"\KajToBylo\" + singelBase.BaseName + @"\config.ktb"))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    singelBase = (Base)bf.Deserialize(input);
                }

                for (int i = 0; i < singelBase.ListCategory.Count; ++i)
                {
                    using (Stream input = File.OpenRead(folder + @"\KajToBylo\" + singelBase.BaseName + @"\" + singelBase.ListCategory[i]))
                    {
                        BinaryFormatter bf = new BinaryFormatter();
                        category.Add((QuestionAnswers)bf.Deserialize(input));
                    }
                }
            }*/



    }
}

