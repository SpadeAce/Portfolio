using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Spade.Item
{
    public class BucketGenerator
    {
        public static Dictionary<string, BaseBucket> Generate()
        {
            Dictionary<string, BaseBucket> BucketList = new Dictionary<string, BaseBucket>();

            BucketList.Add(typeof(GreatBucket).Name, new GreatBucket());
            BucketList.Add(typeof(WhiteBucket).Name, new WhiteBucket());
            BucketList.Add(typeof(RedBucket).Name, new RedBucket());
            BucketList.Add(typeof(BlueBucket).Name, new BlueBucket());
            BucketList.Add(typeof(GreenBucket).Name, new GreenBucket());

            return BucketList;
        }
    }
}