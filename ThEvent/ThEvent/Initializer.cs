using System;
using System.Collections.Generic;
using System.Text;
using ThEvent.Models;
using ThEvent.Data;

namespace ThEvent
{
    public class Initializer
    {
        public void Init()
        {
            //App.Database.ClearTables();  //for debbug
            App.Database.DropTables();
            App.Database.CreateTables();

            var eventList = App.Database.GetEventsAsync();
            if (eventList.Count == 0)
            {
                Event newEv = new Event()
                { 
                    Title = "Фестиваль японской культуры во Владивостоке 6+",
                    Image = "https://omaikane.files.wordpress.com/2018/04/ely-melbmadfest2017-omaikane-14.jpg?w=1200",
                    Info = "Любите «Наруто» и творчество Миядзаки? " +
                    "Завидуете японской средневековой моде и мечтаете о кимоно? " +
                    "Ваши друзья уже освоили разговорный японский, потому что вы с ними общаетесь " +
                    "исключительно на языке страны восходящего солнца? Тогда обязательно приходите " +
                    "на первый ежегодный фестиваль японской культуры! Вас ждут мастер-классы, конкурсы и, " +
                    "конечно же, традиционная чайная церемония.\nРасписание мероприятия: \n9:00 – 10:30 – " +
                    "регистрация\n10:40 – 12:00 – лекция и мастер-класс «Кумихимо. История японского шнура» " +
                    "\n12:10 – 13:00 – Дебаты «Чем 2D лучше, чем 3D»\n13:10 – 14:30 – конкурс поедания рамена " +
                    "\n14:40 – 16:00 – мастер-класс «Рисунок в стиле аниме»\n16:10 – 18:00 – просмотр фильма " +
                    "«Унесенные призраками» под открытым небом\n18:10 – 19:00 – конкурс косплея\n19:10 – 20:00 –" +
                    " конкурс песни на японском\n20:10 – 20:30 – выступление спонсоров конкурса\n20:40 – 22:00 – " +
                    "самая большая в истории Владивостока чайная церемония (лекция и дегустация)\n22:10 – 23:00 – " +
                    "закрытие фестиваля",
                    Date = new DateTime(2020, 2, 28, 9, 0, 0),
                    Address = "Центральная площадь (площадь Борцам за власть Советов)",
                    CreatorId = 1
                };
                _ = App.Database.SaveEventAsync(newEv);
                newEv = new Event()
                { 
                    Title = "Соревнования по спортивному ориентированию 6+",
                    Image = "https://kudago.com/media/images/event/aa/79/aa790c13fc0c1639855ef74ee79f13ef.jpg",
                    Info = "Остров Русский встречает юных и не очень любителей спортивного ориентирования! " +
                    "Вас ждут уникальные природные пейзажи острова и море веселья! Помните, в соревновании " +
                    "можно участвовать как в одиночку, так и командой (3-6 человек), то есть, у вас есть шанс" +
                    " всей семьей побороться за первое место и потрясающие призы! На мероприятии будет организован " +
                    "пункт первой помощи и бесплатный чай с пирожками для участников от наших спонсоров" +
                    " АО«Владхлеб»\nПобедители будут награждены призами от «Спортмастера» и «Приморского кондитера»",
                    Date = new DateTime(2020, 1, 20, 8, 0, 0),
                    Address = "Кампус ДВФУ, главный корпус (6 уровень)",
                    CreatorId = 1
                };
                _ = App.Database.SaveEventAsync(newEv);
                newEv = new Event()
                {
                    Title = "Благотворительный кинопросмотр в «Уссури» 0+",
                    Image = "https://st.kp.yandex.net/im/poster/1/5/2/kinopoisk.ru-The-Lion-King-1529082--o--.jpg",
                    Info = "Благотворительный фонд «Одной крови» совместно с кинотеатром «Уссури» " +
                    "устраивает благотворительный показ мультфильма «Король Лев». Вырученные средства " +
                    "пойдут на покупку игрушек в Арсеньевский детский дом." +
                    "\nСтоимость: 100 рублей",
                    Date = new DateTime(2020, 2, 12, 15, 0, 0),
                    Address = "Кинотеатр «Уссури»",
                    CreatorId = 1
                };
                _ = App.Database.SaveEventAsync(newEv); 
                newEv = new Event()
                {
                    Title = "Вечеринка в стиле 90-ых!!! 18+",
                    Image = "https://heaclub.ru/tim/d2e75bf14e84910455579b84fc3c29ae.jpg",
                    Info = "Ностальгируете по Юрке Шатунову и Сережке Жукову? Или с тоской " +
                    "смотрите семейные фотоальбомы и завидуете родителям, отрывавшимся на вечеринках 90-ых?" +
                    " Тогда ждем вас на потрясающую вечеринку в «San Remo» Вас будет развлекать диджей " +
                    "Biba, а наша команда барменов презентует новые коктейли, придуманные специально для вечеринки!" +
                    "\nСтоимость: 300 рублей",
                    Date = new DateTime(2021, 2, 1, 21, 0, 0),
                    Address = "«San Remo»",
                    CreatorId = 1
                };
                _ = App.Database.SaveEventAsync(newEv);
                newEv = new Event()
                {
                    Title = "Открытая лекция «Метемпсихоз в творчестве Гумилева» 12+",
                    Image = "https://alif.tv/wp-content/uploads/2017/11/gumilev.jpg",
                    Info = "В рамках проекта «Тени Серебрянного века» проводится открытая лекция " +
                    "по творчеству Николая Степановича Гумилева. Наш лектор, А. У. Есиль, подготовил " +
                    "уникальный материал по теме переселения душ в творчестве Гумилева, где он расскажет " +
                    "простыми словами о сложном. Лекция ориентирована на широкого слушателя, но даже специалисты" +
                    " могут узнать много нового о творчестве поэта. По просьбам слушателей в конце мероприятия" +
                    " будет организован открытый микрофон, на площадке которого каждый желающий может зачитать" +
                    " свои любимые стихотворения Гумилева.",
                    Date = new DateTime(2020, 3, 26, 17, 0, 0),
                    Address = "Кампус ДВФУ, коворкинг «Аякс»",
                    CreatorId = 1
                };
                _ = App.Database.SaveEventAsync(newEv);
                newEv = new Event()
                {
                    Title = "Шоу мыльных пузырей на Арбате 0+",
                    Image = "https://sun9-36.userapi.com/c200620/v200620880/3e460/IwYT_jPc39Q.jpg",
                    Info = "Маленькие звездочки из цирковой студии «Мальвина» подготовили удивительный " +
                    "подарок для жителей и гостей города! В первый февральский день они выступят с программой" +
                    " «Волшебные пузырики» на одной из самых любимых улиц города.\nДевочки и мальчики" +
                    " из студии только недавно вернулись из Москвы, где представили эту программу" +
                    " на всероссийском детском цирковом конкурсе «Русский цирк 2019», где заняли " +
                    "2 месте, и теперь они хотят подарить нам немного мыльного сияющего волшебства. " +
                    "\nОдновременно с выступлением на улице расположатся лавки с поделками, сделанными умелыми " +
                    "ручками малышей из центра дошкольной подготовки «Огонек».\n20 % из вырученных средств" +
                    " пойдут на покупку подарков детям, проходящем лечение в онкологической больнице города.",
                    Date = new DateTime(2020, 5, 6, 15, 0, 0),
                    Address = "Улица адмирала Фокина",
                    CreatorId = 1
                };
                _ = App.Database.SaveEventAsync(newEv);
                newEv = new Event()
                {
                    Title = "Городской субботник в Покровском парке 0+",
                    Image = "https://sun9-66.userapi.com/c858120/v858120881/158c9e/AMhYNyxhuio.jpg",
                    Info = "Дорогие друзья, приглашаем Вас принять участие в субботнике, организованном " +
                    "молодежной волонтерской организацией «Мать-земля»! Покровский парк – это место прогулок" +
                    " с детьми, встреч возлюбленных, да и просто отдыха среди деревьев в самом центре " +
                    "шумного города.\nМы должны ценить и беречь это место! Давайте объединим наши силы и" +
                    " очистим наш дорогой парк от мусора, грязи и прошлогодней листвы!\nВсем участникам" +
                    " субботника будут выданы памятные грамоты.",
                    Date = new DateTime(2020, 6, 21, 9, 0, 0),
                    Address = "Покровский парк",
                    CreatorId = 1
                };
                _ = App.Database.SaveEventAsync(newEv);
            }

            var userList = App.Database.GetUsersAsync().Result;
            if (userList.Count == 0)
            {
                User newUs = new User()
                {
                    FirstName = "Admin",
                    SecondName = "",
                    Email = "admin@gmail.com",
                    Password = "123",
                    Age = 20,
                    Sex = "male",
                    Info = "I'm admin!",
                    Image = "https://whatsism.com/uploads/posts/2019-07/1563281010_83b1f339-d4cb-46d4-82d8-8a0ee692f3e0.jpeg",
                    IsAdmin = true
                };
                _ = App.Database.SaveUserAsync(newUs);
                newUs = new User()
                {
                    FirstName = "Александр",
                    SecondName = "Шереметьев",
                    Email = "Shery@mail.ru",
                    Password = "Sobakadog12345",
                    Age = 21,
                    Sex = "male",
                    Info = "Моя жена за рулем – прямо молния! – Что, так быстро ездит? – Нет, попадает в деревьяXDDDD",
                    Image = "https://images.wallpaperscraft.ru/image/kotenok_trava_sidet_nablyudat_lyubopytstvo_56204_1600x1200.jpg",
                    IsAdmin = false
                };
                _ = App.Database.SaveUserAsync(newUs);
                newUs = new User()
                {
                    FirstName = "Антон",
                    SecondName = "Потапов",
                    Email = "Impupa@rambler.ru",
                    Password = "1234567890qwerty",
                    Age = 20,
                    Sex = "male",
                    Info = "Кто завалит экзамен, тот сдохнет))0)",
                    Image = "https://static.myfigurecollection.net/upload/pictures/2019/11/13/2331747.png",
                    IsAdmin = false
                };
                _ = App.Database.SaveUserAsync(newUs);
                newUs = new User()
                {
                    FirstName = "Елена",
                    SecondName = "Арнаут",
                    Email = "Arnaut2017@mail.ru",
                    Password = "Elena1970luchik",
                    Age = 49,
                    Sex = "female",
                    Info = "Очень люблю посещать всякие мероприятия, выставки! Ищу новых друзей! У меня есть МУЖ, просьба МУЖЧИНАМ не писать!",
                    Image = "https://mtdata.ru/u9/photo3142/20798787621-0/original.jpg",
                    IsAdmin = false
                };
                _ = App.Database.SaveUserAsync(newUs);
                newUs = new User()
                {
                    FirstName = "Андрей",
                    SecondName = "Волшебный",
                    Email = "Harrupotter@yandex.ru",
                    Password = "patronus11111",
                    Age = 35,
                    Sex = "male",
                    Info = "Закончил Хогвартс",
                    Image = "https://pbs.twimg.com/media/C9cAX5GXgAA_Nuj.jpg",
                    IsAdmin = false
                };
                _ = App.Database.SaveUserAsync(newUs);
                newUs = new User()
                {
                    FirstName = "Арина",
                    SecondName = "Риврихина",
                    Email = "arivriv@mail.ru",
                    Password = "1092387456",
                    Age = 27,
                    Sex = "female",
                    Info = "Студентка аспирантуры ДВФУ, живу на острове Русском. Ищу друзей для походов в кино!",
                    Image = "https://avatars.mds.yandex.net/get-zen_doc/169683/pub_5cb01b376db23800b0264ec1_5cb01e9a6257ee00b3c6ae04/scale_1200",
                    IsAdmin = false
                };
                _ = App.Database.SaveUserAsync(newUs);
            }
           
            var tagList = App.Database.GetTagsAsync().Result;
            List<string> tagNames = new List<string>{
                "лес", "спортивное_ориентирование",
                "уссури", "кино", "благотворительность", "однойкрови",
                "аниме", "япония", "косплей", "фестиваль",
                "поэзия", "гумилев", "серебрянныйвек", "аякс", "тенисеребрянноговека",
                "шоу", "мыльные_пузыри", "мальвина", "огонек", "благотворительность",
                "вечеринка", "отдых",
                "покровскийпарк", "субботник", "природа", "экология", "волонтерство"
            }; 
            if (tagList.Count == 0)
            {
                int i = 0;
                foreach (var tagName in tagNames)
                {
                    Tag newTag = new Tag()
                    {
                        Title = tagName,
                        Id = ++i
                    };
                    _ = App.Database.SaveTagAsync(newTag);
                }
            }

            //1 фестиваль 2 соревнование 3 кино 4 вечеринка 5 лекция 6 пузыри 7 субботник
            var eventTagsList = App.Database.GetEventTagsAsync().Result;
            if (eventTagsList.Count == 0)
            {
                var e1tags = new List<string> { "аниме", "япония", "косплей", "фестиваль" };
                foreach (var tagName in e1tags)
                {
                    EventTags newET = new EventTags()
                    {
                        EventId = 1,
                        TagId = tagNames.FindIndex(c => c == tagName) + 1
                    };
                    App.Database.SaveEventTagAsync(newET);
                }

                var e2tags = new List<string> { "лес", "природа", "спортивное_ориентирование" };
                foreach (var tagName in e2tags)
                {
                    EventTags newET = new EventTags()
                    {
                        EventId = 2,
                        TagId = tagNames.FindIndex(c => c == tagName) + 1
                    };
                    App.Database.SaveEventTagAsync(newET);
                }

                var e3tags = new List<string> { "уссури", "кино", "благотворительность", "однойкрови" };
                foreach (var tagName in e3tags)
                {
                    EventTags newET = new EventTags()
                    {
                        EventId = 3,
                        TagId = tagNames.FindIndex(c => c == tagName) + 1
                    };
                    App.Database.SaveEventTagAsync(newET);
                }

                var e4tags = new List<string> { "вечеринка", "отдых" };
                foreach (var tagName in e4tags)
                {
                    EventTags newET = new EventTags()
                    {
                        EventId = 4,
                        TagId = tagNames.FindIndex(c => c == tagName) + 1
                    };
                    App.Database.SaveEventTagAsync(newET);
                }

                var e5tags = new List<string> { "поэзия", "гумилев", "серебрянныйвек", "аякс", "тенисеребрянноговека" };
                foreach (var tagName in e5tags)
                {
                    EventTags newET = new EventTags()
                    {
                        EventId = 5,
                        TagId = tagNames.FindIndex(c => c == tagName) + 1
                    };
                    App.Database.SaveEventTagAsync(newET);
                }

                var e6tags = new List<string> { "шоу", "мыльные_пузыри", "мальвина", "огонек", "благотворительность" };
                foreach (var tagName in e6tags)
                {
                    EventTags newET = new EventTags()
                    {
                        EventId = 6,
                        TagId = tagNames.FindIndex(c => c == tagName) + 1
                    };
                    App.Database.SaveEventTagAsync(newET);
                }

                var e7tags = new List<string> { "покровскийпарк", "субботник", "природа", "экология", "волонтерство" };
                foreach (var tagName in e7tags)
                {
                    EventTags newET = new EventTags()
                    {
                        EventId = 7,
                        TagId = tagNames.FindIndex(c => c == tagName) + 1
                    };
                    App.Database.SaveEventTagAsync(newET);
                }
            }

            var userEventsList = App.Database.GetUserEventsAsync().Result;
            if (userEventsList.Count == 0)
            {
                UserEvents newUE = new UserEvents()
                {
                    EventId = 1,
                    UserId = 2
                };
                App.Database.SaveUserEventAsync(newUE);
                newUE = new UserEvents()
                {
                    EventId = 1,
                    UserId = 3
                };
                App.Database.SaveUserEventAsync(newUE);
                newUE = new UserEvents()
                {
                    EventId = 2,
                    UserId = 3
                };
                App.Database.SaveUserEventAsync(newUE);
                newUE = new UserEvents()
                {
                    EventId = 3,
                    UserId = 3
                };
                App.Database.SaveUserEventAsync(newUE);
                newUE = new UserEvents()
                {
                    EventId = 3,
                    UserId = 2
                };
                App.Database.SaveUserEventAsync(newUE);
                newUE = new UserEvents()
                {
                    EventId = 4,
                    UserId = 3
                };
            }
        }
    }
}
