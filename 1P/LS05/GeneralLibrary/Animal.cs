using System;

namespace GeneralLibrary
{
    public class Animal : IDisposable
    {
            public Animal()
            {
                
            }

            ~Animal() // finalizer (destructor) ... deconstructor method ... ARE NOT THE SAME
            {
                if( disposed ) return;
                Dispose(false);
            }
        bool disposed = false;
        public void Dispose() // method will be used by developer
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if(disposed) return;
            // deallocate the unmanaged resource
            if( disposing )
            {
                // deallocate any other unmanaged resource
            }
            disposed = true;
        }
    }
}