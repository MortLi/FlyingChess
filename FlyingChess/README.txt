This is a classic console program for itcast(www.itcast.cn) train.I spend a day to overwrite it.This program can be a little exercise in C sharp.My English  is poor,there must be mistakes in the code,pleace correct.



��Ϸ���ع��̣�
Game Loading Proces
1������Ϸͷ
1 draw game information

2����ʼ����ͼ(���ص�ͼ����Ҫ����Դ)
2 initialize game's  resource

3������ͼ 
3 draw game map

4������Ϸ
4 play game


Flying Chess

��Ϸ����
game rules:

�������������ȡһ��������֣�Ȼ�������������ڵ�ͼ��ǰ����
Two players take turns to get a random number,then they move forward on map.

1��������A�ȵ������B,���B��6�� 
1 If player A meets player B,player B moves six blocks backward.

2���ȵ��˵��ס��6��
2 If a player meets  a landmine(��),the player moves six blocks backward

3���ȵ���ʱ������e����10��
3 If a player meets  a time tunnel(�e),the player moves ten blocks forward.

4���ȵ����������̡򣺽���λ�ã���ը�Է���ʹ�Է���6��
4 If a player meets a lucky wheel(��): changes places with another player or another player moves six blocks.
5�� �ȵ�����ͣ������ͣһ�غϡ�
5 If a player meets a pause(��),the player does nothing next turn.
6���ȵ��˷�������������ɡ�
6 If a player meets a block(��),the player does nothing.
