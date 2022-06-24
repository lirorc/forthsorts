: dumplst ( list size -- ) { lst n -- }
  cr lst n cells dump cr ;

: plst ( list -- ) \ print 0 delimited list
\ eg. lst plst
  cr dup @ .
  cell+ dup @ if recurse else drop then ;

: plstn ( list size -- )
\ eg. lst 15 plstn
  swap dup @ cr . cell+ swap
  1- dup if recurse else drop drop then ;

: thcell ( ptr n -- ptr ) \ zero indexed
\ eg. lst 4 thcell
  cells + ;

: thelem ( ptr n -- n ) \ zero indexed
\ eg. lst 4 thelem
  thcell @ ;

: set ( list index value -- ) { l ix n -- } \ zero indexed
\ eg. mylist 4 1050 set
  n l ix cells + ! ;

: swappair { p -- }
\ eg. here 2 , 4 , swappair
  p @
  p cell+ @
  p !
  p cell+ ! ;

: swapcell { p1 p2 -- }
  p2 @
  p1 @ p2 !
  p1 ! ;

: power { n u -- n^u } \ wrong for u < 2 
  n u 2 - begin swap n * swap 1- dup 0< until drop ;

: base2ceil ( n -- n+e )
  log2 1+ 2 swap power ; \ can just shift too
: base2floor ( n -- n-e )
  log2 2 swap power ;

: odd? ( n -- n )
  1 and ;
