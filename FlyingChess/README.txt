This is a classic console program for itcast(www.itcast.cn) train.I spend a day to overwrite it.This program can be a little exercise in C sharp.My English  is poor,there must be mistakes in the code,pleace correct.



游戏加载过程：
Game Loading Proces
1、画游戏头
1 draw game information

2、初始化地图(加载地图所需要的资源)
2 initialize game's  resource

3、画地图 
3 draw game map

4、玩游戏
4 play game


Flying Chess

游戏规则：
game rules:

两个玩家轮流获取一个随机数字，然后根据这个数字在地图上前进。
Two players take turns to get a random number,then they move forward on map.

1、如果玩家A踩到了玩家B,玩家B退6格。 
1 If player A meets player B,player B moves six blocks backward.

2、踩到了地雷☆，退6格。
2 If a player meets  a landmine(☆),the player moves six blocks backward

3、踩到了时空隧道卐，进10格。
3 If a player meets  a time tunnel(卐),the player moves ten blocks forward.

4、踩到了幸运轮盘◎：交换位置；轰炸对方，使对方退6格。
4 If a player meets a lucky wheel(◎): changes places with another player or another player moves six blocks.
5、 踩到了暂停▲，暂停一回合。
5 If a player meets a pause(▲),the player does nothing next turn.
6、踩到了方块□，神马都不干。
6 If a player meets a block(□),the player does nothing.
