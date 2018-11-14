using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;

public class IAPManager : MonoBehaviour, IStoreListener
{
    private static IStoreController _storeController;
    private static IExtensionProvider _storeExtensionProvider;
    private static string _productID = "test_iap";

    void Start()
    {
        if (_storeController == null)
        {
            InitializePurchasing();
        }
    }

    public void InitializePurchasing()
    {
        if (IsInitialized())
        {
            return;
        }

        var builder = ConfigurationBuilder.Instance(StandardPurchasingModule.Instance());

        builder.AddProduct(_productID, ProductType.Consumable);

        UnityPurchasing.Initialize(this, builder);

        Debug.Log("Initialized Unity IAP");
    }


    private bool IsInitialized()
    {
        return _storeController != null && _storeExtensionProvider != null;
    }


    public void BuyProduct()
    {
        Debug.Log("Started transaction");
        BuyProductID(_productID);
    }


    void BuyProductID(string productId)
    {
        if (IsInitialized())
        {
            Debug.Log("Finding product");
            Product product = _storeController.products.WithID(productId);

            if (product != null && product.availableToPurchase)
            {
                Debug.Log("Found product");
                _storeController.InitiatePurchase(product);
            }
        }
    }
    public void OnInitialized(IStoreController controller, IExtensionProvider extensions)
    {
        _storeController = controller;
        _storeExtensionProvider = extensions;
    }


    public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs args)
    {
        Debug.Log("Processing Purchase");
        if (String.Equals(args.purchasedProduct.definition.id, _productID, StringComparison.Ordinal))
        {
            Social.ReportProgress("CgkIyayZiowBEAIQBA", 100f, (bool success) => { });
        }
        return PurchaseProcessingResult.Complete;
    }

    public void OnInitializeFailed(InitializationFailureReason error)
    {

    }

    public void OnPurchaseFailed(Product i, PurchaseFailureReason p)
    {

    }
}
