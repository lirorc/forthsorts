\ needs : swappair

: sort { l n h -- } \ insertion sort
\ eg. create mylist  5 , 4 , 3 , 2 ,
\     mylist 4 sort
  l cell+ @ l @ < if
    l swappair h if l cell - n h 1- recurse then
    then
  n if l cell+ n 1- h 1+ recurse then ;
: sort ( address size -- ) 2 - 0 sort ;
