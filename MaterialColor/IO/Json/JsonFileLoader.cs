﻿namespace MaterialColor.IO.Json
{
    using MaterialColor.Data;
    using ONI_Common.Data;
    using ONI_Common.Json;
    using System;
    using System.Collections.Generic;
    using UnityEngine;
    using Logger = ONI_Common.IO.Logger;

    public class JsonFileLoader
    {
        private readonly Logger _logger;

        private ConfiguratorStateManager _configuratorStateManager;

        private ElementColorsManager _elementColorInfosManager;

        public JsonFileLoader(JsonManager jsonManager, Logger logger = null)
        {
            this._logger = logger;

            this.InitializeManagers(jsonManager);
        }

        public bool TryLoadConfiguratorState(out MaterialColorState state)
        {
            try
            {
                state = this._configuratorStateManager.LoadMaterialColorState();
                return true;
            }
            catch (Exception ex)
            {
                const string Message = "Can't load configurator state.";

                this._logger.Log(ex);
                this._logger.Log(Message);

                Debug.LogError(Message);

                state = new MaterialColorState();

                return false;
            }
        }

        public bool TryLoadElementColors(out Dictionary<SimHashes, ElementColor> elementColors)
        {
            try
            {
                elementColors = this._elementColorInfosManager.LoadElementColorsDirectory();
                return true;
            }
            catch (Exception e)
            {
                const string Message = "Can't load ElementColorInfos";

                Debug.LogError(Message + '\n' + e.Message + '\n');

                State.Logger.Log(Message);
                State.Logger.Log(e);

                elementColors = new Dictionary<SimHashes, ElementColor>();
                return false;
            }
        }

        private void InitializeManagers(JsonManager manager)
        {
            this._configuratorStateManager = new ConfiguratorStateManager(manager, this._logger);
            this._elementColorInfosManager = new ElementColorsManager(manager, this._logger);
        }
        
    }
}