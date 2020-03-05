#if ENABLE_FIREBASE
using Firebase;
using Firebase.Auth;
#endif

using UnityEngine;

namespace Q.Firebase
{
    public static class Firestorm
    {
        internal const string assetMenuName = nameof(Firebase) + "/";
        internal const string restApiBaseUrl = "https://firestore.googleapis.com/v1beta1";

        /// <summary>
        /// Start building the collection-document path here.
        /// </summary>
        public static FirestormCollectionReference Collection(string name) => new FirestormCollectionReference(name);

        //Prevents garbage collection bug
#if ENABLE_FIREBASE
        private static FirebaseApp appInstance;
#endif
        public static void CreateEditModeInstance()
        {
            if (Application.isPlaying == false)
            {
                DisposeEditModeInstance();
#if ENABLE_FIREBASE
                appInstance = FirebaseApp.Create(FirebaseApp.DefaultInstance.Options, $"TestInstance {Random.Range(10000, 99999)}");
#endif
            }
        }

        public static void DisposeEditModeInstance()
        {
            if (Application.isPlaying == false)
            {
                //Somehow this crashes Unity lol... the network is left running in the other thread it seems.
#if ENABLE_FIREBASE
                appInstance?.Dispose();
#endif
            }
        }

#if ENABLE_FIREBASE
        public static FirebaseApp AppInstance
        {
            get
            {
                if (Application.isPlaying)
                {
                    appInstance = FirebaseApp.DefaultInstance;
                    return appInstance;
                }
                else
                {
                    //Firebase said you should not use default instance in editor (edit mode test also)
                    //https://firebase.google.com/docs/unity/setup#desktop_workflow
                    if (appInstance == null)
                    {
                        throw new FirestormException($"You forgot to call CreateEditModeInstance before running in edit mode");
                    }

                    return appInstance;
                }
            }
        }

        private static FirebaseAuth authInstance;

        public static FirebaseAuth AuthInstance
        {
            get
            {
                if (Application.isPlaying)
                {
                    authInstance = FirebaseAuth.DefaultInstance;
                    return authInstance;
                }
                else
                {
                    authInstance = FirebaseAuth.GetAuth(AppInstance);
                    return authInstance;
                }
            }
        }
#endif
    }
}