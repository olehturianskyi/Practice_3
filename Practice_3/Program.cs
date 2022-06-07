using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*Практика 3
Создайте класс Clock для работы со временем суток, представленным часами, минутами и секундами.
Критерии приемлемости
Получить все входные значения из консоли
Если входные значения имеют неверный формат, распечатайте сообщение об ошибке «Неверный формат».
Программа должна иметь меню для отображения всех возможностей класса Clock.

Структура класса часов:

Три частные переменные:
int Hour: от 0 до 23.
int Минута: от 0 до 59.
int Второй: от 0 до 59.

Два конструктора:
по умолчанию (без параметров; инициализировать представленное время до 12:00:00)
конструктор с тремя параметрами: часы, минуты и секунды.

Добавьте в класс Clock следующие методы:
get-методы getHours() , getMinutes() , getSeconds() без параметров, которые
вернуть соответствующие значения.

setTime(DateTime dateTime), который устанавливает часы, минуты и секунды из DateTime

showTime(), который возвращает информацию о времени в формате чч:мм:сс (например, 11:38:45)

tickDown(), который уменьшает время, хранящееся в объекте Clock, на одну секунду.

addHours(int hours), который добавляет прошедшие часы ко времени, хранящемуся в объекте Clock.
 */
namespace Practice_3
{
    class Clock
    {
        int hours;           
        int minutes;         
        int seconds;         
        DateTime dateTime;
        public Clock()
        {
            this.hours = 12;
            this.minutes = 0;
            this.seconds = 0;
        }
        public Clock(DateTime dateTime)
        {
            this.dateTime = DateTime.Now;
        }
        
        public Clock(int hours, int minutes, int seconds)
        {
            this.hours = hours;
            this.minutes = minutes;
            this.seconds = seconds;
        }
        public int getHours
        {
            get
            { 
                return hours; 
            }
            set
            {
                if (hours < 0 || hours > 23) { Console.WriteLine("Incorrect format!"); } else
                hours = value;
            }
        }
        public int getMinutes
        {
            get
            {
                return minutes;
            }
            set
            {
                if (minutes < 0 || minutes > 60) { Console.WriteLine("Incorrect format!"); }
                else
                    minutes = value;
            }
        }
        public int getSoconds
        {
            get
            {
                return seconds;
            }
            set
            {
                if (seconds < 0 || seconds > 60) { Console.WriteLine("Incorrect format!"); }
                else
                    seconds = value;
            }
        }
        //setTime(DateTime dateTime), который устанавливает часы, минуты и секунды из DateTime
        public DateTime SetTime(DateTime dateTime)
        {
            this.dateTime = DateTime.Now;
            return dateTime;
        }
        public DateTime TickDown()
        {
            this.dateTime = DateTime.Now;
            dateTime = dateTime.AddSeconds(-1);
            return dateTime;
        }
        public DateTime AddHours(int hour)
        {
            this.dateTime = DateTime.Now;
            dateTime = dateTime.AddHours(hour);
            return dateTime;
        }
        public DateTime ShowTime()
        {
            Console.WriteLine(" 1 - Default time\n 2 - System time\n 3 - Time set by the user\n 4 - Уменьшить время\n 5 - Увеличить время\n\n");
           
            int choiсe = Convert.ToInt32(Console.ReadLine());
            if (choiсe == 1)
            {
                Console.Write("Default time: ");
                Clock clock = new Clock();

                string hour = Convert.ToString(clock.getHours);
                string minute = Convert.ToString(clock.getMinutes);
                string second = Convert.ToString(clock.getSoconds);

                string time = hour + ":" + minute + ":" + second;
                
                DateTime time_now = Convert.ToDateTime(time);
                Console.WriteLine(time_now.ToLongTimeString());
                return dateTime;
            }
            if (choiсe == 2)
            {                              
                Console.Write("System time: ");
                Clock clock = new Clock(new DateTime());
                DateTime time = SetTime(dateTime);
               
                Console.WriteLine(dateTime.ToLongTimeString());            
                return dateTime;
            }
            if (choiсe == 3)
            {
                Console.WriteLine("Time set by the user: ");
                Console.WriteLine("Enter hours: ");
                int hours = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter minutes: ");
                int minutes = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter seconds: ");
                int seconds = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine(new string('_', 50));

                Clock clock = new Clock(hours, minutes, seconds);
                
                string hour = Convert.ToString(hours);
                string minute = Convert.ToString(minutes);
                string second = Convert.ToString(seconds);

                string time = hour + ":" + minute + ":" + second;

                DateTime time_now = Convert.ToDateTime(time);
                Console.WriteLine("Time set by the user: " + time_now.ToLongTimeString());
                return dateTime;
            }
            if (choiсe == 4)
            {
                Console.Write("Set time: ");
                Clock clock = new Clock(new DateTime());
                DateTime time = SetTime(dateTime);
                
                Console.WriteLine(dateTime.ToLongTimeString());
                time = TickDown();
                Console.Write("Time reduced by 1 second: ");
                Console.WriteLine(dateTime.ToLongTimeString());
                return dateTime;
            }
            if (choiсe == 5)
            {
                Console.Write("Set time: ");
                Clock clock = new Clock(new DateTime());
                DateTime time = SetTime(dateTime);

                Console.WriteLine(dateTime.ToLongTimeString());
                Console.WriteLine("How many hours to add?");
                int hour = Convert.ToInt32(Console.ReadLine());
                time = AddHours(hour);
                Console.Write("Added " + hour + " hours: ");
                Console.WriteLine(dateTime.ToLongTimeString());
                return dateTime;
            }
            else { return DateTime.Now; }
        }
        internal class Program
        {
            static void Main(string[] args)
            {
                Clock clock = new Clock();
                clock.ShowTime();

                Console.ReadLine();
            }
        }
    }
}
