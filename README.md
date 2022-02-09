# ffmpeg-net - .NET Wrapper for FFmpeg libraries

The project is in active development. The API may change.

## Requirements
- [FFmpeg 5.0](https://www.ffmpeg.org/) libraries: avcodec-59, avdevice-59, avfilter-8, avformat-59, avutil-57, postproc-56, swresample-4, swscale-6
- [.NET 6.0](https://dotnet.microsoft.com/en-us/download/dotnet/6.0)

## Features

- Getting the list of supported container formats, codecs, decoders and coders.
- Getting the list of supported input and output devices.
- Getting information about media files:
  * streams: codec, framerate, pixel format, resolution for video; samplerate, sample format, channel layout for audio;
  * chapters;
  * metadata at all levels: media file, stream, chapter.

## TBD
- Decoding and reencoding video and audio
- Getting audio and video from devices like microphone, camera, etc.
- Documentation
