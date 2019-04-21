﻿using UnityEngine;
using System.Collections.Generic;
using protocol.cs_theircraft;

public static class BlockGenerator
{
    public static Dictionary<CSBlockType, string> type2icon = new Dictionary<CSBlockType, string>
    {
        {CSBlockType.Grass, "grass" },
        {CSBlockType.Dirt, "dirt" },
        {CSBlockType.Tnt, "tnt" },
        {CSBlockType.Brick, "brick" },
        {CSBlockType.Furnace, "furnace" },
        {CSBlockType.HayBlock, "hayblock" },
    };

    public static Dictionary<CSBlockType, string> type2breakEffect = new Dictionary<CSBlockType, string>
    {
        {CSBlockType.Grass, "dirt" },
        {CSBlockType.Dirt, "dirt" },
        {CSBlockType.Tnt, "tnt_side" },
        {CSBlockType.Brick, "brick" },
        {CSBlockType.Furnace, "furnace_front_off" },
        {CSBlockType.HayBlock, "hay_block_side" },
    };

    static Dictionary<CSBlockType, GameObject> blockType2prefab = new Dictionary<CSBlockType, GameObject>();

    public static GameObject GetBlockPrefab(CSBlockType type)
    {
        if (!blockType2prefab.ContainsKey(type))
        {
            string path = string.Format("Prefabs/Blocks/{0}", type2icon[type]);
            blockType2prefab[type] = Resources.Load(path) as GameObject;
        }
        return blockType2prefab[type];
    }
    static public GameObject CreateCube(CSBlockType type)
    {
        return Object.Instantiate(GetBlockPrefab(type));
    }
}
