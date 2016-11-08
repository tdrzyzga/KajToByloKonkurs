using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.Windows.Data;
using System.Windows.Controls;

namespace KajToBylo
{
    class Collections
    {
        public CollectionView CollectionMusicPL { get; private set; }
        public CollectionView CollectionMusicSL { get; private set; }
        public CollectionView CollectionMovie { get; private set; }
        public CollectionView CollectionBook { get; private set; }

        private ObservableCollection<QuestionAnswers> collectionMusicPL;
        private ObservableCollection<QuestionAnswers> collectionMusicSL;
        private ObservableCollection<QuestionAnswers> collectionMovie;
        private ObservableCollection<QuestionAnswers> collectionBook;
        
        private string filterText;

        public Collections()
        {
            collectionMusicPL = new ObservableCollection<QuestionAnswers>();
            collectionMusicSL = new ObservableCollection<QuestionAnswers>();
            collectionMovie = new ObservableCollection<QuestionAnswers>();
            collectionBook = new ObservableCollection<QuestionAnswers>();

            CollectionMusicPL = new CollectionView(collectionMusicPL);
            CollectionMusicPL = (CollectionView)CollectionViewSource.GetDefaultView(collectionMusicPL);
            CollectionMusicPL.Filter = questionSearch;

            CollectionMusicSL = new CollectionView(collectionMusicSL);
            CollectionMusicSL = (CollectionView)CollectionViewSource.GetDefaultView(collectionMusicSL);
            CollectionMusicSL.Filter = questionSearch;

            CollectionMovie = new CollectionView(collectionMovie);
            CollectionMovie = (CollectionView)CollectionViewSource.GetDefaultView(collectionMovie);
            CollectionMovie.Filter = questionSearch;

            CollectionBook = new CollectionView(collectionBook);
            CollectionBook = (CollectionView)CollectionViewSource.GetDefaultView(collectionBook);
            CollectionBook.Filter = questionSearch;


        }

        private bool questionSearch(object item)
        {
            QuestionAnswers question = item as QuestionAnswers;

            if (filterText == null || question.Question.Contains(filterText))
                return true;
            else
                return false;
        }

        public void Refresh(TextBox texBox)
        {
            filterText = texBox.Text;
            
            switch (texBox.Name)
            {
                case "filterMusicPL":
                    CollectionMusicPL.Refresh();
                    break;
                case "filterMusicSL":
                    CollectionMusicSL.Refresh();
                    break;
                case "filterMovie":
                    CollectionMovie.Refresh();
                    break;
                case "filterBook":
                    CollectionBook.Refresh();
                    break;
            }
        }

        public void AddItem(QuestionAnswers question)
        {
            var collection = setCategory(question.CategoryIndex);
            collection.Insert(0, question);
        }

        public void SetCollection(MainWindow.IndexCategory indexCategory, Category category)
        {
            var collection = setCategory(indexCategory);
            foreach (var i in category.ReturnListQuestions())
                collection.Add(i);
        }

        public void RemoveItem(QuestionAnswers question)
        {
            var collection = setCategory(question.CategoryIndex);
            collection.Remove(question);
        }

        public void ChangeItem(QuestionAnswers questionBeforeChanges, QuestionAnswers questionAfterChanges)
        {
            var collection = setCategory(questionBeforeChanges.CategoryIndex);
            collection[collection.IndexOf(questionBeforeChanges)] = questionAfterChanges;
        }

        public void Clear()
        {
            collectionMusicPL.Clear();
            collectionMusicSL.Clear();
            collectionMovie.Clear();
            collectionBook.Clear();
        }

        private ObservableCollection<QuestionAnswers> setCategory(MainWindow.IndexCategory category)
        {
            if (MainWindow.IndexCategory.MusicPL == category)
                return collectionMusicPL;
            else if (MainWindow.IndexCategory.MusicSL == category)
                return collectionMusicSL;
            else if (MainWindow.IndexCategory.Movie == category)
                return collectionMovie;
            else
                return collectionBook;
           
        }
    }
}
