: lc ( -- ptr )            \ left cell
  here 2 cells - ;
: rc ( -- ptr )            \ right cell
  here cell- ;
: lp++ ( -- )
  1 lc +! ;
: rp-- ( -- )
  -1 rc +! ;

: lp
  lc @ ;
: rp
  rc @ ;

: segregate ( list size n -- splitindex ) { l s n -- ix }
  0 ,                     \ left pointer
  s 1- ,                  \ right pointer

  begin
    lp rp < while

    begin
      lp rp <
      l lp thelem n <= and while
      lp++
      repeat
    begin
      lp rp <
      l rp thelem n > and while
      rp--
      repeat

    l lp thelem
    l rp thelem > if
      l lp thcell
      l rp thcell
      swapcell
      then
    repeat
  rp                      \ return index
  2 cells negate allot ;  \ remove left and right ptr

: qsort ( list size -- ) { l s -- }
  l
  s
  l @ l s 1- thelem + 2/
  segregate                    \ sort against average
  dup 0> s 2 > and if          \ list not empty
    dup
    l swap  recurse            \ sort left side

    dup
    l swap cells +
    swap s swap - recurse      \ sort right side
    else drop
    then ;
