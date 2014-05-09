using SharpRepository.Repository.Aspects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharpRepository.Repository.SaveStrategy
{
    public abstract class SaveStrategyBase
    {
        protected Func<bool> QuerySaveExecuting;
        protected Action BroadcastSaveExecuted;
        protected Action SaveChanges;
        protected Action<Exception> ErrorHandler;
        public SaveStrategyBase(ISaveStrategyClient client)
        {
            QuerySaveExecuting = client.QuerySaveExecuting;
            BroadcastSaveExecuted = client.BroadcastSaveExecuted;
            SaveChanges = client.SaveChanges;
            ErrorHandler = client.ErrorHandler;
        }
        public abstract void Save();
    }

    public class DefaultSaveStrategy : SaveStrategyBase
    {
        public DefaultSaveStrategy(ISaveStrategyClient client)
            : base(client)
        {

        }
        public override void Save()
        {
            try
            {
                QuerySaveExecuting();
                SaveChanges();
                BroadcastSaveExecuted();

            }
            catch (Exception ex)
            {
                ErrorHandler(ex);
                throw;
            }
        }

    }
    public class ContainerSaveStrategy : SaveStrategyBase
    {
        public ContainerSaveStrategy(ISaveStrategyClient client, EventHandler savedEvent)
            : base(client)
        {
            
        }
        public override void Save()
        {
        }
    }
}
