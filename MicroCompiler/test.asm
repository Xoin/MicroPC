#fristbyte: const 1
#test: const 2
#db "test$"

#test
#mov fristbyte R0
store R0 1
mov R0 R5
store R1 2
cmp R0 R1 R2
jnzero R2 gohere
store R4 8
gohere:
store R3 4
inc R1
dec R4
halt
#db "can we like fill this thing"
store R0 5