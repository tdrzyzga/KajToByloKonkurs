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

        public void SetCategory(QuestionAnswers question)
        {
            dictinaryCategory[question.CategoryIndex].AddQuestion(question);
        }

        public void DeleteQuestion(QuestionAnswers question)
        {
            dictinaryCategory[question.CategoryIndex].DeleteQuestion(question);
        }

        public void ChangeQuestion(QuestionAnswers questionBeforeChanges, QuestionAnswers questionAfterChanges)
        {
            dictinaryCategory[questionBeforeChanges.CategoryIndex].ChangeQuestion(questionBeforeChanges, questionAfterChanges);
        }
        
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

        public bool ReadALL(string folder)
        {
            bool result = true;
   
            for (int i = 0; i < dictinaryCategory.Count; i++)
            {
                if (File.Exists(folder + @"\" + KajToBylo.MainWindow.NameCategory[i] + @".ktb"))
                {
                    using (Stream input = File.OpenRead(folder + @"\" + KajToBylo.MainWindow.NameCategory[i] + @".ktb"))
                    {
                        BinaryFormatter bf = new BinaryFormatter();

                        dictinaryCategory[(KajToBylo.MainWindow.IndexCategory)i].AddQuestionRange((Category)bf.Deserialize(input));
                    }

                    result = true;
                }
                else
                {
                    System.Windows.MessageBox.Show("Nie można otworzyć bazy " + folder);
                    result = false;
                    break;
                }
            }
            return result;
        }
    }
}

