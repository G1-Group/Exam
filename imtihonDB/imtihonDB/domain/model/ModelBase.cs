namespace imtihonDB.domain.model
{
    public abstract class ModelBase
    {
        public int id = 0;

        public int GetId()
        {
            return id++;
        }
    }
}