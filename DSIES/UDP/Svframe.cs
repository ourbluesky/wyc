using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSIES.UDP
{
    public class Svframe
    {
        public Svframe()
        {
           
        }

        public Svframe(
            float time,
            float x,
            float y,
            float speed,
            float acc,
            float stwAngle,
            float offset,
            float accelerograph,
            float brake,
            float distance,
            float braking,
            float reacting,
            float area,
            float farToFront,
            float lane,
            float trLight)
        {
            this.time = time;
            this.x = x;
            this.y = y;
            this.speed = speed;
            this.acc = acc;
            this.stwAngle = stwAngle;
            this.offset = offset;
            this.brake = brake;
            this.distance = distance;
            this.accelerograph = accelerograph;
            this.braking = braking;
            this.reacting = reacting;
            this.area = area;
            this.farToFront = farToFront;
            this.lane = lane;
            this.trLight = trLight;
        }

        private float time;         // 行驶时间
        private float x;            // 车的坐标x
        private float y;            // 车的坐标y
        private float speed;        // 速度
        private float acc;          // 加速度
        private float stwAngle;     // 方向盘转角
        private float offset;       // 偏离道路中心线距离
        private float accelerograph;//油门踏板
        private float brake;        // 刹车踏板
        private float distance;     // 总行驶距离
        private float braking;      // 刹车状态 0-否 1-是
        private float reacting;     // 反应状态 0-未进入反应阶段或反应结束 1-反应中
        private float area;         // 区域标记
        private float farToFront;   // 与前车的距离
        private float farToBehind;  // 与后车的距离
        private float lane;         // 车道
        private float trLight;      // 信号灯.0关1左转2右转

        public float Time
        {
            get { return time; }
            set { time = value; }
        }

        public float X
        {
            get { return x; }
            set { x = value; }
        }
        public float Y
        {
            get { return y; }
            set { y = value; }
        }

        public float Speed
        {
            get { return speed; }
            set { speed = value; }
        }

        public float Acc
        {
            get { return acc; }
            set { acc = value; }
        }

        public float StwAngle
        {
            get { return stwAngle; }
            set { stwAngle = value; }
        }

        public float Offset
        {
            get { return offset; }
            set { offset = value; }
        }
        public float Accelerograph
        {
            get { return accelerograph; }
            set { accelerograph = value; }
        }

        public float Brake
        {
            get { return brake; }
            set { brake = value; }
        }

        public float Distance
        {
            get { return distance; }
            set { distance = value; }
        }

        public float Braking
        {
            get { return braking; }
            set { braking = value; }
        }

        public float Reacting
        {
            get { return reacting; }
            set { reacting = value; }
        }

        public float Area
        {
            get { return area; }
            set { area = value; }
        }

        public float FarToFront
        {
            get { return farToFront; }
            set { farToFront = value; }
        }

         private float FarToBehind
        {
            get { return farToBehind; }
            set { farToBehind = value; }
        }

        public float Lane
        {
            get { return lane; }
            set { lane = value; }
        }


        public float TrLight
        {
            get { return trLight; }
            set { trLight = value; }
        }
    }
}



