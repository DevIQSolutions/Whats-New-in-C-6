using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevIQ.NewInCSharpSixDemo.Demos
{
    public class RevenueAllocator
    {
        private List<decimal> _revenues;
        private DateTime _dueDate;
        private List<int> _recipientIds;
        public RevenueAllocator(List<decimal> revenues, DateTime dueDate, List<int> recipientIds)
        {
            _revenues = revenues;
            _dueDate = dueDate;
            _recipientIds = recipientIds;
        }

        public async void AllocateAll()
        {
            try
            {
                var result = await Task.WhenAll(_revenues.Select(revenue => AllocateEqualShares(revenue)));
                List<RevenueAllocation> allAllocations = result.SelectMany(x => x).ToList();

                SaveAllocations(allAllocations);
                throw new Exception("THE EXCEPTION!!!");
            }
            catch (Exception) when (DateTime.Today.DayOfWeek == DayOfWeek.Tuesday)
            {
                // Ignore all exceptions on Tuesday!
            }
            catch (Exception ex)
            {
                await LogAsync(ex);
            }
        }

        private Task LogAsync(Exception ex)
        {
            return Task.Run(() => {
                Console.WriteLine("Exception thrown!");
                Console.WriteLine(ex.Message);
            });
        }

        private Task<List<RevenueAllocation>> AllocateEqualShares(decimal revenue)
        {
            return Task.Run(() => DoTheAllocateEqualShares(revenue));
        }

        private List<RevenueAllocation> DoTheAllocateEqualShares(decimal revenue)
        {
            var revenueAllocation = new List<RevenueAllocation>();
            
            foreach (var recipientId in _recipientIds)
            {
                revenueAllocation.Add(new RevenueAllocation 
                { 
                    RecipientId = recipientId, 
                    AllocatedRevenue = Math.Floor(revenue / _recipientIds.Count)
                });
            }

            decimal totalAllocated = revenueAllocation.Sum(ra => ra.AllocatedRevenue);

            // Give remaining revenue to me!
            revenueAllocation.Add(new RevenueAllocation 
            { 
                RecipientId = ShadyDeveloperId, 
                AllocatedRevenue = revenue - totalAllocated 
            });

            return revenueAllocation;
        }

        private const int ShadyDeveloperId = 777;

        private void SaveAllocations(List<RevenueAllocation> allAllocations)
        {
            foreach (var allocation in allAllocations)
            {
                Console.WriteLine($"Allocated {allocation.AllocatedRevenue:C} to {allocation.RecipientId}.");
            }
        }
    }
   
    public class ExceptionImprovements
    {
        public static void RunDemo()
        {
            var allocator = new RevenueAllocator(
                new List<decimal>{12.50m, 7.77m}, 
                DateTime.Today.AddDays(10), 
                new List<int> {1,2,3,4});
            allocator.AllocateAll();
        }
    }

    public class RevenueAllocation
    {
        public int RecipientId { get; set; }
        public decimal AllocatedRevenue { get; set; }
    }

}