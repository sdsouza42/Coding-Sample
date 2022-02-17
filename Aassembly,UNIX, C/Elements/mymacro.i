.macro	Mul10	reg

	add	\reg, \reg
	mov	edx, \reg
	add	\reg, \reg
	add	\reg, \reg
	add	\reg, edx

.endm



