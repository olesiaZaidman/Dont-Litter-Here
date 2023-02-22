
public interface IUIIndicator
{
    float CalculateNormalizedValue(float _fillValue, float _maxValue);
    void SetImageFillAmountAndColor(float _value);
    void UpdateFill();
    void IncreaseFill();
    void DecreaseFill();
    void ZeroFill();
    //   float NormalizedMaxValue { get; set; }
}
