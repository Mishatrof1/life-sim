INCLUDE age_1_3.ink
INCLUDE Result.ink 
INCLUDE age_3_5.ink
INCLUDE age_over_5_friends
INCLUDE age_over_5



 
VAR PlayerAge = 1
VAR NpcName = "npc name"
VAR PlayerGender = "male"
VAR NpcGender = "male"
VAR FriendStatus = false
VAR Relationship = 0
VAR Health = 0
  
Коммуникейшн с {NpcName}

 {
 - PlayerAge < 4:
    -> age_1_3
 } 
 {
 - PlayerAge >4 && PlayerAge <6:
    -> age_3_5
 } 
 {
 - PlayerAge >5:
    {FriendStatus :
    -> age_over_5_friends
    - else:
    -> age_over_5
    }
 }




