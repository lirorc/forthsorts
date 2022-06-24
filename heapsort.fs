\ -- I say list, you say array -- \
: parent ( n -- n )
\ can rewrite without branching
  dup odd?
  if 1- 2/
  else 2 - 2/ then ;

: left ( n -- n )
  2* 1+ ;
: right ( n -- n )
  2* 2 + ;

: bubbleup ( ptr index -- ) { p ix -- }
  ix 0> if
    p ix thelem
    p ix parent thelem
    < if
      p ix thcell
      p ix parent thcell
      swapcell
      p ix parent recurse
      then
    then ;

: push ( ptr size val -- ) { p s n -- }
  p s n set \ add to bottom
  p s bubbleup ;

: bubbledown ( list index length -- ) { l ix n -- }
  l 40 plstn cr ." --- "
  n 0> if
    l ix left thelem 0>
    l ix left thelem
    l ix right thelem < and
    l ix right thelem 0= or if
      l ix thcell
      l ix left thcell
      swapcell
      l ix left n 2/ recurse
      else
      l ix thcell
      l ix right thcell
      swapcell
      l ix right n 2/ recurse
      then
    then ;

: pop ( ptr length -- n ) { p l -- }
  l 0> if
    p @
    0 p !
    p 0 l bubbledown
    then ;

: heapsort ( list size -- ) { l s -- }
\ eg. create mylist 3 , 2 , 1 ,
\     mylist 3 heapsort
  here s cells erase
  s 0 do
    here i l i thelem push loop
  s 0 do
    l
    i
    here s pop
    set
    loop ;
