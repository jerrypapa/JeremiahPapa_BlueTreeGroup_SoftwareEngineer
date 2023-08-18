using NUnit.Framework;
using Moq;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Supermarket.Checkout.Application.CommandHandlers;
using Supermarket.Checkout.Application.Commands;
using Supermarket.Checkout.Application.Exceptions;
using Supermarket.Checkout.Application.Queries;
using Supermarket.Checkout.Application.QuerryHandlers;
using Supermarket.Checkout.Application.Services;
using Supermarket.Checkout.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.Checkout.Tests
{
    [TestFixture]
    public class CheckoutServiceTests
    {
        private Dictionary<char, Product> pricingRules;

        [SetUp]
        public void Setup()
        {
            pricingRules = new Dictionary<char, Product>
            {
                { 'A', new Product('A', 50, 3, 130) },
                { 'B', new Product('B', 30, 2, 45) },
                { 'C', new Product('C', 20) },
                { 'D', new Product('D', 25) }
            };
        }



        [Test]
        public void Handle_InvalidItem_ThrowsInvalidItemException()
        {

            var scanItemCommand = new ScanItemCommand('B');
            var cancellationToken = new CancellationToken();
            var handler = new ScanItemCommandHandler(pricingRules);

            // Assert
            Assert.Throws<InvalidItemException>(() => handler.Handle(scanItemCommand, cancellationToken).Wait());
        }

        [Test]
        public async Task CalculateTotal_WithNoSpecialPrices_ShouldCalculateCorrectly()
        {

            var products = new Dictionary<char, int>
        {
            { 'A', 2 },
            { 'B', 1 },
            { 'C', 3 },
        };

            var query = new GetTotalQuery();
            var handler = new CalculateTotalQueryHandler(pricingRules, products);

            // Act
            var total = await handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.AreEqual(2 * 50 + 1 * 30 + 3 * 20, total);
        }

        [Test]
        public async Task CalculateTotal_WithSpecialPrices_ShouldCalculateCorrectly()
        {

            var products = new Dictionary<char, int>
        {
            { 'A', 5 },
            { 'B', 2 },
            { 'C', 1 },
        };

            var query = new GetTotalQuery();
            var handler = new CalculateTotalQueryHandler(pricingRules, products);

            // Act
            var total = await handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.AreEqual(2 * 130 + 1 * 50 + 1 * 30 + 1 * 20, total);
        }
    }
}
