using Ninject.Modules;
using NLayerApp.BLL.Services;
using NLayerApp.BLL.Interfaces;

namespace NLayerApp.WEB.Util
{
    public class LeaseModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ILeaseService>().To<LeaseService>();
            Bind<IBooksService>().To<BooksService>();
            Bind<IStudentsService>().To<StudentsService>();
        }
    }
}