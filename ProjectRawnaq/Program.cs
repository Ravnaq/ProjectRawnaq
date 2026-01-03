using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRawnaq
{
    class TaskItem
    {
        public string Title { get; set; }
        public int Priority { get; set; }   
        public int Duration { get; set; }   
        public int DeadlineDay { get; set; } 
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            List<TaskItem> tasks = new List<TaskItem>();

            Console.Write("chanta fazifa dored? ");
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"\n{i + 1}-vazifa:");

                Console.Write("Nomi: ");
                string title = Console.ReadLine();

                Console.Write("bahoguzori (1-5): ");
                int bahoguzori = int.Parse(Console.ReadLine());

                Console.Write("vaqt (minut): ");
                int vaqt = int.Parse(Console.ReadLine());

                Console.Write("ruz (0=Imruz, 1=paga, 2=fardo): ");
                int ruz = int.Parse(Console.ReadLine());

                tasks.Add(new TaskItem
                {
                    Title = title,
                    Priority = bahoguzori,
                    Duration = vaqt,
                    DeadlineDay = ruz
                });
            }

            var sortedTasks = tasks
                .OrderByDescending(t => t.Priority)
                .ThenBy(t => t.DeadlineDay)
                .ThenBy(t => t.Duration)
                .ToList();

            int rank = 1;
            foreach (var t in sortedTasks)
            {
                Console.WriteLine(
                    $"{rank}. {t.Title} | bahoguzori: {t.Priority}, kadomruz: {t.DeadlineDay}, vaqt: {t.Duration} minut");
                rank++;
            }

            Console.ReadKey();
        }
    }
}
