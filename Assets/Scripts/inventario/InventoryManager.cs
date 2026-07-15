using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public int inventorySize = 20;
    public List<InventorySlot> slots = new List<InventorySlot>();

    void Start()
    {
        // Inicializa o inventário com slots vazios
        for (int i = 0; i < inventorySize; i++)
        {
            slots.Add(new InventorySlot());
        }
    }

    // Função principal que você vai chamar quando coletar algo
    public bool AddItem(ItemData itemToAdd, int amountToAdd)
    {
        // tenta encontrar um slot que já tenha esse item e que não esteja cheio
        foreach (InventorySlot slot in slots)
        {
            if (slot.item == itemToAdd && slot.amount < itemToAdd.maxStackSize)
            {
                int spaceLeftInSlot = itemToAdd.maxStackSize - slot.amount;

                if (amountToAdd <= spaceLeftInSlot)
                {
                    // Cabe tudo neste slot
                    slot.AddAmount(amountToAdd);
                    UpdateUI();
                    return true;
                }
                else
                {
                    // Enche este slot e calcula o que sobrou para o próximo
                    slot.AddAmount(spaceLeftInSlot);
                    amountToAdd -= spaceLeftInSlot;
                }
            }
        }

        // 2. Se sobrou item (ou não tinha nenhum no inventário), procura um slot vazio
        foreach (InventorySlot slot in slots)
        {
            if (slot.IsEmpty())
            {
                if (amountToAdd <= itemToAdd.maxStackSize)
                {
                    // Ocupa o slot vazio com o total
                    slot.item = itemToAdd;
                    slot.amount = amountToAdd;
                    UpdateUI();
                    return true;
                }
                else
                {
                    // Ocupa o slot vazio com o máximo permitido e repete para o restante
                    slot.item = itemToAdd;
                    slot.amount = itemToAdd.maxStackSize;
                    amountToAdd -= itemToAdd.maxStackSize;
                }
            }
        }

        Debug.Log("Inventário cheio! Não foi possível adicionar todos os itens.");
        return false; // Retorna falso se não houver espaço para tudo
    }

    private void UpdateUI()
    {
        // chamar o script da UI para atualizar as imagens e os textos.
        // O ideal é usar Actions (Eventos) aqui, mas para manter simples no começo,
        // da pra referenciar o script de UI diretamente.
    }
}