
public interface IUIIndicator
{
  //  float CalculateNormalizedValue(float _fillValue, float _maxValue);
    void SetImageFillAmountAndColor(float _value);
    void UpdateFill(float _normValue);

    void ChangeShadowColorIfNeeded(bool _isTrue);

//    void IncreaseFill();
//  void DecreaseFill();
//  void ZeroFill();
//   float NormalizedMaxValue { get; set; }
}
