namespace SuperPOS.Domain.Entities
{
    //选择改码结果集合类
    public class TaExtraResult
    {
        public virtual int rID { get; set; }

        public virtual string rType { get; set; }

        public virtual string rItemName { get; set; }

        public virtual string rOtherItemName { get; set; }

        public virtual string rPrice { get; set; }
    }
}