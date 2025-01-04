﻿using CodeBase.Gameplay.Cameras;
using CodeBase.Gameplay.Levels;
using UnityEngine;
using Zenject;

namespace CodeBase.Infrastraction.Installers
{
    public class LevelInitializer : MonoBehaviour, IInitializable
    {
        public Camera MainCamera;
        public Transform StartPoint;
        private ICameraProvider _cameraProvider;
        private ILevelDataProvider _levelDataProvider;

        [Inject]
        private void Construct(ICameraProvider cameraProvider, ILevelDataProvider levelDataProvider)
        {
            _levelDataProvider = levelDataProvider;
            _cameraProvider = cameraProvider;
        }
        public void Initialize()
        {
            _levelDataProvider.SetStartPoint(StartPoint.position);
            _cameraProvider.SetMainCamera(MainCamera);
        }
    }
}