using System.Collections;
using System.Numerics;

namespace JJJ26
{
    class Student
    {
        public string name;         // 이름
        public int grade;           // 학년
        public int classRoom;    // 반
        public int number;          // 학번

        // 정렬을 위한 변수
        // public int SortNum => grade * 10000 + classRoom * 100 + number;

        // 비트 연산을 활용
        // << : 왼쪽으로 n만큼 비트 이동한다
        public int SortNum => (grade << 16) + (classRoom << 8) + number;
        public Student(string name, int grade, int classRoom, int number)
        {
            this.name = name;
            this.grade = grade;
            this.classRoom = classRoom;
            this.number = number;
        }    

        public override string ToString()
        {
            return $"{name} : {grade}-{classRoom}반 {number}번";
        
        }
    }

    class Item
    {
        public string name;
    }
    class EquipItem : Item
    {
        public EquipItem(string name)
        {
            this.name = name;
        }
    }
    class UserItem : Item
    {
        public UserItem(string name)
        {
            this.name = name;
        }
    }
    class Victory
    {
        public string team;
        public List<int> year;
        public Victory(string team, params int[] year)
        {
            this.team = team;
            this.year = year.ToList();
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            // 1교시
            /*
            Student[] students = new Student[]
            {
                new Student("학생A", 1,1,10),
                new Student("학생B", 1,1,11),
                new Student("학생C", 1,1,12),
                new Student("학생D", 2,1,13),
                new Student("학생E", 2,2,14),
                new Student("학생F", 2,2,15),
                new Student("학생G", 3,2,16),
                new Student("학생H", 3,2,17),
                new Student("학생I", 3,2,18)
            };

            // Thenby : OrderBy를 이용해 정렬한 배열을 다시 한번 배열한다.
            Console.WriteLine(string.Join("\n", students.OrderBy(s => s.grade).ThenBy(s=>s.number)));

            var group = students.GroupBy(s => s.grade);     // 학생들을 학년 기준으로 그룹을 짓는다.
            foreach (var student in group)
            {
                // IGrouping : 키, 값 한 쌍으로 이루어지는 데이터를 가지는 인터페이스. 키를 기준으로 구분 짓는다.
                // key값은 그룹의 기준이 되는 요소의 공통값으로 정해진다.
                Console.WriteLine(string.Join(',', student.Key));
                foreach(var key in student)
                {
                    Console.WriteLine($"{key}");
                }
                
            }
*/

            // 2교시
            /*
            // OfType : 특정 자료형으로 변환할 수 있는 값들만 가져온다.
            ArrayList array = new ArrayList();
            array.Add(1234);
            array.Add(5678);  
            array.Add(999);
            array.Add("aaa");
            array.Add("bbb");
            array.Add("Ccc");

            // 배열에서 string타입만 가져온다.
            var findString = array.OfType<string>();
            Console.WriteLine(string.Join(',', findString));

            List<Item> inven = new List<Item>();
            inven.Add(new EquipItem("장비A"));
            inven.Add(new UserItem("소모품A"));
            inven.Add(new EquipItem("장비C"));
            inven.Add(new UserItem("소모품D"));
            inven.Add(new EquipItem("장비D"));
            inven.Add(new UserItem("소모품E"));
            inven.Add(new UserItem("소모품B"));
            inven.Add(new EquipItem("장비B"));
            inven.Add(new UserItem("소모품C"));
            inven.Add(new EquipItem("장비E"));

            // 인벤에서 장비 아이템만 가져온다
            var findEqiup = inven.OfType<EquipItem>();
            foreach (var item in findEqiup)
            {
                Console.WriteLine(item.name);
            }
*/

            // Contains : bool => 어떠한 집합 안에 특정한 값이 포함되어 있는가?
            string str = "aceg";
            Console.WriteLine($"{str}에 알파벳a가 포함되어 있는가? {str.Contains('a')}");

            // All : bool => 모든 집합이 임의의 조건을 만족시키는가?
            Console.WriteLine($"{str}에 문자들이 전부 홀수인가? {str.All((c) => c % 2 == 1)}");

            // Any : bool => 집합의 모든 요소 중에서 조건을 만족하는 것이 하나라도 있는가?
            Console.WriteLine($"{str}에 짝수가 있는가? {str.Any((c) => c % 2 == 0)}");

            // Select => 값을 추출하여 시퀀스를 만든다.
            int[] array = { 1, 2, 3, 4, 5, 6, 7, 8 };
            string[] arrayStr = array.Select(x => x.ToString()).ToArray();

            // SelectMany => 배열 안에 배열이 또 있는 경우에 사용하는 Select문
            // 여러개의 원본 값으로부터 시퀀스를 만든다.
            Victory[] victories = new Victory[]
            {
                new Victory("한국", 1983, 1997,2002,2012),
                new Victory("영국", 1985, 1998,2001,2011),
                new Victory("미국", 1989, 1999,2006,2016),
                new Victory("중국", 1986, 1990,2008,2018)
            };

            // 파라미터가 하나 일 때 => 집합 내부의 특정 집합들을 하나의 스퀀스로 만들었다.
            var Vyear = victories.SelectMany(w => w.year);

            foreach(var year in Vyear)
            { Console.WriteLine(year); }

            // 파라미터가 2개일 때
            // => 첫번째 매개변수에서 반환된 v.year이 두번째 매개변수 y로 전달 되었다.
            // n번째 v와 집합 y를 반복해서 호출

            var findVictory = victories.SelectMany(v => v.year, (v, y) => new { year= y, team = v.team});

            foreach(var item in findVictory)
            {
                Console.WriteLine(item);
            }


            // ForEach
            Array.ForEach(findVictory.ToArray(), v => Console.WriteLine(v));

            // ad가 포함된 배열 지우기
            string[] strs = { "asd","aaa","adee","adsdad","assd" };
            strs = RemoveAd(strs);
            foreach(string s in strs)
            {
                Console.WriteLine($"{s}");
            }

            Console.WriteLine(UnderComposite(50));
            // 1,2,3,5,7
        }
        public static string[] RemoveAd(string[] strs)
        {
            return strs.Where(s => !s.Contains("ad")).ToArray();
        }

        public static bool IsComposite(int num)
        {
            int nr = (int)Math.Sqrt(num);
            for (int i = 2; i <= nr; i++)
            {
                if (num % i == 0)
                {
                    return true;
                }
            }

            return false;
        }
        // num 받고 그보다 작은 합성수들의 개수 반환 
        public static int UnderComposite(int num)
        {
            int count = 0;
            List<int> list = new List<int>();

            for(int i = 2; i < num; i++)
            {
                if (IsComposite(i))
                {
                    count++;
                    list.Add(i);
                }
            }
            Console.WriteLine(string.Join(",", list));
            return count;
        }
    }
}