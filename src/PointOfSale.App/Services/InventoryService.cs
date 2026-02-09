using Microsoft.EntityFrameworkCore;
using PointOfSale.App.Data;
using PointOfSale.App.Models;

namespace PointOfSale.App.Services;

public sealed class InventoryService
{
    private readonly AppDbContext _dbContext;

    public InventoryService(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IReadOnlyList<InventoryItem>> GetLowStockItemsAsync()
    {
        return await _dbContext.InventoryItems
            .Include(item => item.Product)
            .Where(item => item.QuantityOnHand <= item.ReorderPoint)
            .OrderBy(item => item.Product!.Name)
            .ToListAsync();
    }

    public async Task RecordInventoryAdjustmentAsync(InventoryAdjustment adjustment)
    {
        _dbContext.InventoryAdjustments.Add(adjustment);

        var inventoryItem = await _dbContext.InventoryItems
            .FirstOrDefaultAsync(item => item.ProductId == adjustment.ProductId);

        if (inventoryItem != null)
        {
            inventoryItem.QuantityOnHand += adjustment.QuantityChanged;
        }

        await _dbContext.SaveChangesAsync();
    }
}
