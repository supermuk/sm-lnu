#include <iostream>

using namespace std;

template<typename _T>
class Item
{
    _T data;
public:
    Item()
        : data()
    {
    }
    const _T& get_data() const 
    {
        return data;
    }
};

int main()
{
    Item<int> a;

    cout << a.get_data() << endl;
    return 0;
}