## Project
summary-unity-drawing-a-long-note-in-music-game
How to draw a smooth long note in music game at unity engine.

## Topic
https://w8grrsutrc.feishu.cn/record/G4gLr83wTenIuOcIXjfcBkp8nvc

## Environment
- Unity 2022.3.55f1

### Lane & Time
在下落式音游玩法中，需要先定义下落轨道（Lane），与判定时间（Time）概念。
所有的音符都是围绕这两个概念去配置、显示与判定。
可以将 Lane & Time 抽象的看为 X Y 轴坐标系，通过 Lane & Time 可以确定当前音符显示的位置。
实际的宽高位置根据屏幕坐标二次映射。
```json
// 假设一个长按的配置如下
{
    "Lane": 0, // 第 0 轨
    "Time": 1000, // 音乐开始后 1000 毫秒开始判定
    "Duration": 1000, // 判定开始后，持续 1000 毫秒后结束
    // 没有其他配置，这里假设长按后续没有变轨
}
```
### 曲线如何绘制
曲线可以想象为由多个点连线组成，点越多，曲线越平滑。

如何求得这些点？


### 三次贝塞尔曲线
```
Tutorial Video: https://www.youtube.com/watch?v=Q12sb-sOhdI
起点与终点不变，通过调整两个控制点来达到目标平滑的效果。
```
### 绘制
```
```


## 实际开发中的遇到的问题
- 为什么曲线在慢速条件下不平滑？
    - 慢速条件下，曲线中间部分会明显有凹凸感。
- 如何绘制头尾被扣掉？
- 如何绘制尾部类似 ES2？


