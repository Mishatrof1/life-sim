VAR NpcName = "npc name" 
VAR Relationship = 53
VAR FriendStatus = false
VAR Pronoun = "He"
VAR Sex = "female"
VAR Gender1 = "He"
VAR Gender2 = "him" 
VAR PopUpState = true

{Sex == "female":
~Gender1 = "she"
}
Today i meet {NpcName}. {Gender1} looks very good.
    * [Ok]-> END