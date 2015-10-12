using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace radarsystem
{
    public enum TabOptionEnum
    {
        SCEN=0,
        FEATURE=1
    }

    public enum NoiseEnum
    {
        NoNoise = -1,
        GUASSIAN=0,
        POISSON=1,
        UNIFORM=2
    }
    public enum Coordinate
    {
        X=0,
        Y=1
    }

    public enum Scene
    {
        DOPPLER=0,           //多普勒雷达
        MULTIBASE=1,         //多基地雷达
        BVR=2,               //BEYOND VISUAL RANGE 超视距雷达
        ACT_SONAR=3,         //声呐（主动）
        PAS_SONAR=4,         //声呐（被动）
        ELEC_VS = 5,         //电子对抗
        COMMAND = 6,         //指挥控制
    }
}
