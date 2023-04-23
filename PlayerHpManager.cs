using VContainer;

namespace Scripts
{
    public class PlayerHpManager
    {
        private DbConnection dbConnection;
        private Player Player;

        public PlayerHpManager(DbConnection dbConnection, Player player)
        {
            this.dbConnection = dbConnection;
            Player = player;
        }
    }
}