using System;
using SpiderButt;

public class patch_RoomStartEvent : RoomStartEvent
{
    
    public extern void orig_Execute();
    public override void Execute()
    {
        Utils utils = new Utils();
        
        Console.WriteLine("[SpiderButt] PreRoomStartEvent begin");
        utils.ExecuteEvents("PreRoomStartEvent");
        orig_Execute();
        Console.WriteLine("[SpiderButt] PostRoomStartEvent begin");
        utils.ExecuteEvents("PostRoomStartEvent");
    }
}

public class patch_ClearPuzzleEvent : ClearPuzzleEvent
{
    public extern void orig_Execute();
    public override void Execute()
    {
        Utils utils = new Utils();
        
        Console.WriteLine("[SpiderButt] PreClearPuzzleEvent begin");
        utils.ExecuteEvents("PreClearPuzzleEvent");
        orig_Execute();
        Console.WriteLine("[SpiderButt] PostClearPuzzleEvent begin");
        utils.ExecuteEvents("PostClearPuzzleEvent");
    }
}