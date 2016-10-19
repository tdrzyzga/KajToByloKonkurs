using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace KajToBylo
{
    class Collections
    {
        public ObservableCollection<QuestionAnswers> CollectionMusicPL { get; private set; }
        public ObservableCollection<QuestionAnswers> CollectionMusicSL { get; private set; }
        public ObservableCollection<QuestionAnswers> CollectionMovie { get; private set; }
        public ObservableCollection<QuestionAnswers> CollectionBook { get; private set; }

        public Collections()
        {
            CollectionMusicPL = new ObservableCollection<QuestionAnswers>();
            CollectionMusicSL = new ObservableCollection<QuestionAnswers>();
            CollectionMovie = new ObservableCollection<QuestionAnswers>();
            CollectionBook = new ObservableCollection<QuestionAnswers>();
        }

        public void AddItemsToCollections(MainWindow.IndexCategory index, QuestionAnswers question)
        {
            switch (index)
            {
                case MainWindow.IndexCategory.MusicPL:
                    CollectionMusicPL.Insert(0, question);
                    break;
                case MainWindow.IndexCategory.MusicSL:
                    CollectionMusicSL.Insert(0, question);
                    break;
                case MainWindow.IndexCategory.Movie:
                    CollectionMovie.Insert(0, question);
                    break;
                case MainWindow.IndexCategory.Book:
                    CollectionBook.Insert(0, question);
                    break;
            }
        }

        public void SetCollections(MainWindow.IndexCategory index, Category category)
        {
            switch (index)
            {
                case MainWindow.IndexCategory.MusicPL:
                    foreach (var i in category.ReturnListQuestions())
                        CollectionMusicPL.Add(i);
                    break;
                case MainWindow.IndexCategory.MusicSL:
                    foreach (var i in category.ReturnListQuestions())
                        CollectionMusicSL.Add(i);
                    break;
                case MainWindow.IndexCategory.Movie:
                    foreach (var i in category.ReturnListQuestions())
                        CollectionMovie.Add(i);
                    break;
                case MainWindow.IndexCategory.Book:
                    foreach (var i in category.ReturnListQuestions())
                        CollectionBook.Add(i);
                    break;
            }
        }

        public void DeleteItem(MainWindow.IndexCategory index, QuestionAnswers question)
        {
            switch (index)
            {
                case MainWindow.IndexCategory.MusicPL:
                    CollectionMusicPL.Remove(question);
                    break;
                case MainWindow.IndexCategory.MusicSL:
                    CollectionMusicSL.Remove(question);
                    break;
                case MainWindow.IndexCategory.Movie:
                    CollectionMovie.Remove(question);
                    break;
                case MainWindow.IndexCategory.Book:
                    CollectionBook.Remove(question);
                    break;
            }
        }

        public void ChangeItem(MainWindow.IndexCategory category, QuestionAnswers questionBeforeChanges, QuestionAnswers questionAfterChanges)
        {
            switch (category)
            {
                case MainWindow.IndexCategory.MusicPL:
                    CollectionMusicPL[CollectionMusicPL.IndexOf(questionBeforeChanges)] = questionAfterChanges;
                    break;
                case MainWindow.IndexCategory.MusicSL:
                    CollectionMusicSL[CollectionMusicSL.IndexOf(questionBeforeChanges)] = questionAfterChanges;
                    break;
                case MainWindow.IndexCategory.Movie:
                    CollectionMovie[CollectionMovie.IndexOf(questionBeforeChanges)] = questionAfterChanges;
                    break;
                case MainWindow.IndexCategory.Book:
                    CollectionBook[CollectionBook.IndexOf(questionBeforeChanges)] = questionAfterChanges;
                    break;
            }
        }

        public void Clear()
        {
            CollectionMusicPL.Clear();
            CollectionMusicSL.Clear();
            CollectionMovie.Clear();
            CollectionBook.Clear();
        }
    }
}
