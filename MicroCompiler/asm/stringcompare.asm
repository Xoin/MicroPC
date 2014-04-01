store R0 1
load R1 text
int 1
load R2 text2
store R0 4
int 1
halt
text:
db "Hello World!$"
text2: