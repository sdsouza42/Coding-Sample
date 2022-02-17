.intel_syntax noprefix

.include "console.i"

.data

array:	.long	111, 222, 333, 444, 555, 666, 777, 888
index:	.long	0
value:	.long	0

.text

ask:	.asciz	"Index (0-7): "
ans:	.asciz	"Value = "
fin:	.asciz	"Goodbye."

_entry:
	Prompt	ask
	GetInt	index

	lea	ebx, array
	mov	esi, index		#direct addressing
	mov	eax, [ebx+4*esi]	#indirect addressing
	mov	value, eax

	Prompt	ans
	PutInt	value
	PutEoL
	Prompt	fin
	PutEoL

	ret

.global _entry

.end

