using Samples;
using static Samples.Information;

if (args.Length > 0 && !string.IsNullOrWhiteSpace(args[0]))
{
    PrintMediaFileInfo(args[0]);
}
else
{
    //PrintChannelLayouts();
    //PrintCodecs();
    //PrintInputFormats();
    //PrintOutputFormats();
    //PrintInputDevices();
    //PrintOutputDevices();

    //Devices.ShowCameraAndMicrophoneInfo();
    Devices.TakeFrameFromCamera();
}
