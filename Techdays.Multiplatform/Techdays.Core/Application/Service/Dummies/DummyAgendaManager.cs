using System;
using System.Collections.Generic;
using System.Linq;
using Cirrious.MvvmCross.Plugins.File;
using Cirrious.MvvmCross.Plugins.Json;
using Techdays.Core.Application.Interfaces;

namespace Techdays.Core.Application.Service.Dummies
{
    public class DummyAgendaManager : IManageAnAgenda
    {
        private readonly AgendaSaver _favoritesSaver = new AgendaSaver();

        private List<int> _allItems;

        public void Add(int sessionId)
        {
            if (_allItems == null)
                _allItems = new List<int>();

            if (!IsInAgenda(sessionId))
            {
                _allItems.Add(sessionId);
                _favoritesSaver.RequestAsyncSave(_allItems.Select(i => i.ToString()).ToList());
                FireSessionAdded();
            }
        }

        private void FireSessionAdded()
        {
            var handler = SessionAdded;
            if (handler != null)
                handler(this, EventArgs.Empty);

        }

        public bool IsInAgenda(int sessionId)
        {
            if (_allItems == null)
            {
                var items = _favoritesSaver.LoadAgenda();
                if (items == null)
                    return false;
                _allItems = items.Select(int.Parse).ToList();
            }

            return _allItems.Contains(sessionId);
        }

        public event EventHandler SessionAdded;
    }
}