using ASP.NET_Core_Example.Example1DI.Abstractions;
using ASP.NET_Core_Example.Example1DI.Services;

namespace ASP.NET_Core_Example.Example1DI
{
    // Плохой подход
    public class BadService
    {
        // Dependency - зависимость
        private readonly EmailSender _sender;

        // Вариант 1. Injection (инъекция, впрыск) - внедрение зависимости с помощью конкретной реализации (без абстрагирования через интерфейс)
        public BadService(EmailSender emailSender)
        {
            _sender = emailSender;

            // Вариант 2. Вообще не внедрение зависимости
            _sender = new EmailSender();
        }

        // Оба варианта - нарушение принципа Depenpency Inversion по SOLID!!!
        // Второй вариант похож на похож на инверсию зависимостей, но мы попрежнему зависим от реализации, а не абстракции.


        public void Notify(string executor)
        {
            string message = "Уведомляем Вас, что дедлайн по текущей задаче позавчера!";

            _sender.Send(message, executor);
        }
    }

    // Хороший подход
    public class NiceService
    {
        // Dependency - зависимость
        private readonly ISender _sender;

        // Injection (инъекция, впрыск) - внедрение зависимости. Через конструктор! И с помощью интерфейса!
        public NiceService(ISender sender)
        {
            _sender = sender;
        }

        // SOLID не нарушен - Дядюшка Боб (Мартин) очень рад!

        public void Notify(string executor)
        {
            string message = "Уведомляем Вас, что дедлайн по текущей задаче позавчера!";

            _sender.Send(message, executor);
        }
    }


    public class User
    {
        public void Use()
        {
            ISender emailSender = new EmailSender();
            NiceService niceService = new NiceService(emailSender);

            niceService.Notify("bestProgrammer");

            ISender smsSender = new SMSSender();
            niceService = new NiceService(smsSender);

            niceService.Notify("bestProgrammer");

            // Очень сложно, создание объектов-зависимостей и их внедрение и все это в рекурсии - похоже на overengineering

            // Но принцип DI нам нравится, как реализация Dependency Injection

            /// Решение: отдать всю сложную работу кому то другому (Инверсия контроля).
            /// Для этого существуют IoC или правильнее DI-контейнеры (контейнеры Dependency Injection). Некоторые из них - Ninject, Autofac и, конечно же, наш .NET'овский.
        }
    }

    //#region Про DI!
    //private void Hidden(IServiceCollection services)
    //{
    //    // Наш .NET'овский DI(или еще называют IoC)-контейнер

    //    // Правильно через интерфейс
    //    services.AddSingleton<ISender, EmailSender>(); // Singleton

    //    // Не очень хорошо, но пойдет ... до поры до времени :)
    //    services.AddScoped<NiceService>(); // Scoped
    //    services.AddTransient<ExactCurrentTimeService>(); // Transient
    //}
    //#endregion
}
