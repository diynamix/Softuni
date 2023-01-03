using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace IteratorsAndComparators
{
    public class Library : IEnumerable<Book>
    {
        private List<Book> books;

        public Library(params Book[] books)
        {
            this.books = books.ToList();
        }

        public IEnumerator<Book> GetEnumerator()
        {
            return new LibraryIterator(this.books);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
            //return new LibraryIterator(this.books);
        }

        public class LibraryIterator : IEnumerator<Book>
        {
            private List<Book> books;
            private int currentIndex; // = -1

            public LibraryIterator(List<Book> books)
            {
                this.books = books;
                Reset();
            }

            public Book Current => this.books[currentIndex];

            object IEnumerator.Current => this.Current;

            public void Dispose()
            {
            }

            public bool MoveNext()
            {
                this.currentIndex++;
                return currentIndex < books.Count;
            }

            public void Reset()
            {
                this.currentIndex = -1;
            }
        }
    }
}