VAR AgeMinCondition = 30
VAR AgeMaxCondition = 50
VAR SexCondition = "Female"
VAR GroupTitle = "?????"
VAR TextForLog = ""



VAR ChangeHappiness = 0
VAR ChangeLooks = 0
VAR ChangeSmarts = 0
VAR ChangeHealth = 0

? ???? ? ?????????? ? ?? ???? ?????? ???? ?????? ?????. ??? ???????
* [?? ??????????????. ?????????? ? ???? ????]
    -> res1
* [??????????!]
    -> res2
* [?????? ? ???? ???!]
    -> res3


=== res1 === 
????? ???????, ? ?????????? ? ???? ???? ? ?? ???????????. ??????, ??? ?????? ????????? ??? ????????
~TextForLog = "? ???? ? ?????????? ? ?? ???? ?????? ???? ?????? ?????. ? ?????????? ? ???? ???? ? ?????????? ?????? ??????????? ?????????."
* [Ok]
-> END
=== res2 === 
?????? ??????! ? ??? ????????. ? ??????????, ???????? ??????????, ?????? ????????, ?? ????? ????????. ?? ? ????????!
~TextForLog = "? ???? ? ?????????? ? ?? ???? ?????? ???? ?????? ?????. ? ???????? ? ???????? ? ????????, ???? ??? ???? ?????????: ???????? ?????????, ?????? ????????, ???? ??????????."
* [Ok]
-> END
=== res3 === 
??? ???????????? ????, ?? ?? ??????. ? ???????? ????
~TextForLog = "? ???? ? ?????????? ? ?? ???? ?????? ???? ?????? ?????. ? ?????? ?? ??? ?????? ? ???????? ????."
* [Ok]
-> END
