.intel_syntax noprefix

.include "console.i"

.data

length:		.long	0
breadth:	.long	0
perim:		.long	0

.text

askl:		.asciz	"Length: "
askb:		.asciz	"Breadth: "
ans:		.asciz	"Perimeter = "
FIVE:		.long	5

_entry:
	Prompt	askl
	GetInt	length
	Prompt	askb
	GetInt	breadth

	mov	eax, length	#eax=L
	add	eax, breadth	#eax=(L+B)
	add	eax, eax	#eax=2*(L+B)
	mov	perim, eax

	Prompt	ans
	PutInt	perim
	PutEoL

	ret

.global _entry

.end


