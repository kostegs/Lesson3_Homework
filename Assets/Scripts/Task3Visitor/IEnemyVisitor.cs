namespace Visitor
{
    public interface IEnemyVisitor
    {
        void Visit(OrkConfig orkConfig);
        
        void Visit(HumanConfig humanConfig);
        
        void Visit(ElfConfig elfConfig);

        void Visit(EnemyConfig enemyConfig);
    }
}
