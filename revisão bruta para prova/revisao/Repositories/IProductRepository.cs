using System;
using revisao.Models;

namespace revisao.Repositories;

public interface  IProductRepository
{
    List<Product> List();
    Product? SearchId(int id);
    void Create(Product product);
    void Update(Product product);
    void Delete(Product product);
    void Save();
}
