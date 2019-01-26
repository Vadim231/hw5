using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Common;


namespace HomeWork5
{
    public class Program
    {
        public static void Main(string[] args)
        {
            DataSet libraryDS = new DataSet("Library");
            
            libraryDS.ExtendedProperties["DataSetID"] = Guid.NewGuid();
            libraryDS.ExtendedProperties["Company"] = "Моя библиотека";

            

            FillDataSet(libraryDS);
            PrintDataSet(libraryDS);

            Console.ReadLine();
        }

        public static void PrintDataSet(DataSet ds)
        {
            // Вывод имени и расширенных свойств
            Console.WriteLine("--- DataSet ---\n");
            Console.WriteLine("Имя DataSet: {0}", ds.DataSetName);
            foreach (System.Collections.DictionaryEntry de in ds.ExtendedProperties)
                Console.WriteLine("Ключ = {0}, Значение = {1}", de.Key, de.Value);
            Console.WriteLine();

            // Вывод каждой таблицы
            foreach (DataTable dt in ds.Tables)
            {
                Console.WriteLine("*** Таблица: {0}", dt.TableName);

                // Вывод имени столбцов
                for (int curCol = 0; curCol < dt.Columns.Count; curCol++)
                    Console.Write(dt.Columns[curCol].ColumnName + "\t");
                Console.WriteLine("\n");

                // Выводим содержимое таблицы
                for (int curRow = 0; curRow < dt.Rows.Count; curRow++)
                    for (int curCol = 0; curCol < dt.Columns.Count; curCol++)
                        Console.WriteLine(dt.Rows[curRow][curCol].ToString() + "\t");
                Console.WriteLine();
            }
        }

        public static void FillDataSet(DataSet ds)
        {
            //TABLE BOOK
            DataColumn bookIDColumn = new DataColumn("bookID", typeof(int));
            bookIDColumn.Caption = "Book ID";
            bookIDColumn.ReadOnly = true;
            bookIDColumn.AllowDBNull = false;
            bookIDColumn.Unique = true;

            DataColumn bookAutorColumn = new DataColumn("Autor", typeof(string));
            DataColumn bookNameColumn = new DataColumn("Name", typeof(string));
            DataColumn bookPublicDate = new DataColumn("Publication date", typeof(DateTime));


            DataTable bookTable = new DataTable("Book");
            bookTable.Columns.AddRange(new DataColumn[] { bookIDColumn, bookAutorColumn, bookNameColumn, bookPublicDate });

            //TABLE READER
            DataColumn readerIDColumn = new DataColumn("readerId", typeof(int));
            readerIDColumn.Caption = "Reader ID";
            readerIDColumn.ReadOnly = true;
            readerIDColumn.AllowDBNull = false;
            readerIDColumn.Unique = true;

            DataColumn readerNameColumn = new DataColumn("Name", typeof(string));
            DataColumn readerSecondNameColumn = new DataColumn("SecondName", typeof(string));
            
            DataTable readerTable = new DataTable("Reader");
            readerTable.Columns.AddRange(new DataColumn[] { readerIDColumn, readerNameColumn, readerSecondNameColumn });

            //TABLE WORKER
            DataColumn workerIDColumn = new DataColumn("workerId", typeof(int));
            workerIDColumn.Caption = "Worker ID";
            workerIDColumn.ReadOnly = true;
            workerIDColumn.AllowDBNull = false;
            workerIDColumn.Unique = true;

            DataColumn workerNameColumn = new DataColumn("Name", typeof(string));
            DataColumn workerSecondNameColumn = new DataColumn("SecondName", typeof(string));

            DataTable workerTable = new DataTable("Worker");
            workerTable.Columns.AddRange(new DataColumn[] { workerIDColumn, workerNameColumn, workerSecondNameColumn });


            ds.Tables.Add(bookTable);
            ds.Tables.Add(readerTable);
            ds.Tables.Add(workerTable);
        }
    }
}
