#ifndef PRINTING_H
#define PRINTING_H

#include <iostream>

namespace Generic
{
	template<typename ForwardIterator>
	void PrintAll(ForwardIterator begin, ForwardIterator end)
	{
		for(ForwardIterator i = begin; i != end; ++i)
		{
			std::cout << *i << ' ';
		}

		std::cout << std::endl;
	}

	template<typename ForwardIterator, typename UnaryPredicate>
	void PrintIf(ForwardIterator begin, ForwardIterator end, UnaryPredicate allowed)
	{
		for(ForwardIterator i = begin; i != end; ++i)
		{
			if(allowed(*i))
				std::cout << *i << ' ';
		}

		std::cout << std::endl;
	}
}


#endif


