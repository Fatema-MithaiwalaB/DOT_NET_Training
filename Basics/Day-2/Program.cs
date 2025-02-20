// See https://aka.ms/new-console-template for more information


using Day_2;

ListLINQ list = new ListLINQ();
 bool result = list.MakeList();
//checking if input is valid or not
if (result) { 
list.GroupedNums();
list.FilterAndOrder();
}


